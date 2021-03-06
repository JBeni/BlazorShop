// <copyright file="PaymentsController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
	/// <summary>
	/// Controller for Payments.
	/// </summary>
	[Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class PaymentsController : ApiControllerBase
    {
		private readonly IConfiguration _configuration;

		public PaymentsController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
        [HttpPost("create-subscription")]
        public async Task<IActionResult> CreateSubscriptionSession([FromBody] CreateSubscriberCommand req)
        {
			var options = new SessionCreateOptions
			{
				SuccessUrl = "https://localhost:7066/subscription-success/subscription-made",
				CancelUrl = "https://localhost:7066/musics",
				PaymentMethodTypes = new List<string>
				{
					"card",
				},
				Mode = "subscription",
				LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						Price = req.StripeSubscriptionId,
						Quantity = 1,
					},
				}
            };

			try
            {
				var service = new SessionService();
				var session = await service.CreateAsync(options);

				return Ok(session.Url);
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
				return BadRequest();
            }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stripeSubscriptionCreationId"></param>
		/// <returns></returns>
		[HttpDelete("cancel-subscription/{stripeSubscriptionCreationId}")]
		public async Task<IActionResult> CancelSubscriptionSession(string stripeSubscriptionCreationId)
		{
			try
			{
				var subscriptionService = new SubscriptionService();
				subscriptionService.Cancel(stripeSubscriptionCreationId);

				await Mediator.Send(new UpdateSubscriberStatusCommand
				{
					StripeSubscriberSubscriptionId = stripeSubscriptionCreationId,
				});

				return Ok();
			}
			catch (StripeException e)
			{
				Console.WriteLine(e.StripeError.Message);
				return BadRequest();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[HttpPost("update-subscription")]
		public async Task<IActionResult> UpdateSubscriptionSession([FromBody] UpdateSubscriberCommand req)
		{
            var subscriptionService = new SubscriptionService();
			subscriptionService.Cancel(req.StripeSubscriberSubscriptionId);

			await Mediator.Send(new UpdateSubscriberStatusCommand
			{
				StripeSubscriberSubscriptionId = req.StripeSubscriberSubscriptionId,
			});

            var options = new SessionCreateOptions
			{
				SuccessUrl = "https://localhost:7066/update-subscription-success/subscription-made",
				CancelUrl = "https://localhost:7066/musics",
				PaymentMethodTypes = new List<string>
				{
					"card",
				},
				Mode = "subscription",
				LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						Price = req.StripeSubscriptionId,
						Quantity = 1,
					},
				}
			};

			try
			{
				var service = new SessionService();
				var session = await service.CreateAsync(options);

				return Ok(session.Url);
			}
			catch (StripeException e)
			{
				Console.WriteLine(e.StripeError.Message);
				return BadRequest();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartItems"></param>
		/// <returns></returns>
		[HttpPost("checkout")]
        public IActionResult CreateCheckout([FromBody] List<CartResponse> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(x => lineItems.Add(
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = x.Price * 100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = x.Name,
                            //Images = new List<string> { x.Image }
                        }
                    },
                    Quantity = x.Amount,
                })
            );

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7066/order-success/success-made",
                CancelUrl = "https://localhost:7066/carts",
            };

            /**
             * https://localhost:7066/order-success
             * SuccessUrl = https://localhost:44351/api/Payments/checkout-response?session_id={CHECKOUT_SESSION_ID}
             */

            var service = new SessionService();
            Session session = service.Create(options);

            return Ok(session.Url);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("webhook")]
		public async Task<IActionResult> WebHook()
		{
			var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

			try
			{
				var stripeEvent = EventUtility.ConstructEvent(
					json,
					Request.Headers["Stripe-Signature"],
					_configuration["StripeSettings:WebHookKey"]
				);

				// Handle the event
				switch (stripeEvent.Type)
                {
					case Events.CheckoutSessionCompleted:
						await CompleteAcceptCheckout(stripeEvent);
						break;
					case Events.CustomerSubscriptionCreated:
						var subscription = stripeEvent.Data.Object as Subscription;
						var service = new InvoiceService();
						var invoiceData = service.Get(subscription.LatestInvoiceId);

						await Mediator.Send(new UpdateCreatedSubscriberCommand
                        {
							CurrentPeriodEnd = subscription.CurrentPeriodEnd,
							CurrentPeriodStart = subscription.CurrentPeriodStart,
							CustomerEmail = invoiceData.CustomerEmail,
							StripeSubscriberSubscriptionId = subscription.Id,
							HostedInvoiceUrl = invoiceData.HostedInvoiceUrl,
                        });
						break;
/*
					case Events.CustomerSubscriptionUpdated:
						var subscriptionUpdate = stripeEvent.Data.Object as Subscription;
						var serviceUpdate = new InvoiceService();
						var invoiceDataUpdate = serviceUpdate.Get(subscriptionUpdate.LatestInvoiceId);

						await Mediator.Send(new UpdateCreatedSubscriberCommand
						{
							CurrentPeriodEnd = subscriptionUpdate.CurrentPeriodEnd,
							CurrentPeriodStart = subscriptionUpdate.CurrentPeriodStart,
							CustomerEmail = invoiceDataUpdate.CustomerEmail,
							StripeSubscriberSubscriptionId = subscriptionUpdate.Id,
							HostedInvoiceUrl = invoiceDataUpdate.HostedInvoiceUrl,
						});
						break;
*/
					default:
						break;
				}
				return Ok();
			}
			catch (StripeException e)
			{
				Console.WriteLine(e.StripeError.Message);
				return BadRequest();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stripeEvent"></param>
		/// <returns></returns>
		private async Task CompleteAcceptCheckout(Event stripeEvent)
        {
			var sessionData = stripeEvent.Data.Object as Session;
			var service = new PaymentIntentService();
			var result = service.Get(sessionData.PaymentIntentId);

			var sessionService = new SessionService();
			StripeList<LineItem> lineItems = sessionService.ListLineItems(sessionData.Id);

			List<InvoiceResponse> items = new();
			foreach (var item in lineItems.Data)
			{
				var invoice = new InvoiceResponse
				{
					Name = item.Description,
					AmountSubTotal = Convert.ToInt32(item.AmountSubtotal) / 100,
					AmountTotal = Convert.ToInt32(item.AmountTotal) / 100,
					Quantity = Convert.ToInt32(item.Quantity)
				};
				items.Add(invoice);
			}
			var orderCommand = new CreateOrderCommand
			{
				UserEmail = sessionData.CustomerDetails.Email,
				OrderDate = DateTime.Now,
				LineItems = JsonSerializer.Serialize(items),
				AmountTotal = Convert.ToInt32(sessionData.AmountTotal) / 100
			};

			await Mediator.Send(orderCommand);
			await Mediator.Send(new CreateReceiptCommand
			{
				UserEmail= sessionData.CustomerDetails.Email,
				ReceiptDate = DateTime.Now,
				ReceiptName = "Receipt Nr. " + Guid.NewGuid(),
				ReceiptUrl = result.Charges.Data.FirstOrDefault().ReceiptUrl
			});
		}
	}
}
