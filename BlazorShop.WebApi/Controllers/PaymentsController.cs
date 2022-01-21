using System.Text.Json;

namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = "User, Default")]
    public class PaymentsController : ApiControllerBase
    {
		private readonly IConfiguration _configuration;

		public PaymentsController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		//[HttpPost("create-checkout-session")]
		//public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest req)
		//{
		//	var options = new SessionCreateOptions
		//	{
		//		SuccessUrl = req.SuccessUrl,
		//		CancelUrl = req.FailureUrl,
		//		PaymentMethodTypes = new List<string>
		//		{
		//			"card",
		//		},
		//		Mode = "subscription",
		//		LineItems = new List<SessionLineItemOptions>
		//		{
		//			new SessionLineItemOptions
		//			{
		//				Price = req.PriceId,
		//				Quantity = 1,
		//			},
		//		},
		//	};

		//	var service = new SessionService();
		//	service.Create(options);
		//	try
		//	{
		//		var session = await service.CreateAsync(options);
		//		return Ok(new CreateCheckoutSessionResponse
		//		{
		//			SessionId = session.Id,
		//			PublicKey = _stripeSettings.PublicKey
		//		});
		//	}
		//	catch (StripeException e)
		//	{
		//		Console.WriteLine(e.StripeError.Message);
		//		return BadRequest(new ErrorResponse
		//		{
		//			ErrorMessage = new ErrorMessage
		//			{
		//				Message = e.StripeError.Message,
		//			}
		//		});
		//	}
		//}

		//[Authorize]
		//[HttpPost("customer-portal")]
		//public async Task<IActionResult> CustomerPortal([FromBody] CustomerPortalRequest req)
		//{

		//	try
		//	{
		//		ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
		//		var claim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
		//		var userFromDb = await _userManager.FindByNameAsync(claim.Value);

		//		if (userFromDb == null)
		//		{
		//			return BadRequest();
		//		}
		//		var options = new Stripe.BillingPortal.SessionCreateOptions
		//		{
		//			Customer = userFromDb.CustomerId,
		//			ReturnUrl = req.ReturnUrl,
		//		};
		//		var service = new Stripe.BillingPortal.SessionService();
		//		var session = await service.CreateAsync(options);

		//		return Ok(new
		//		{
		//			url = session.Url
		//		});
		//	}
		//	catch (StripeException e)
		//	{
		//		Console.WriteLine(e.StripeError.Message);
		//		return BadRequest(new ErrorResponse
		//		{
		//			ErrorMessage = new ErrorMessage
		//			{
		//				Message = e.StripeError.Message,
		//			}
		//		});
		//	}

		//}

		[HttpGet("checkout-response")]
        public async Task<IActionResult> GetCheckoutResponse([FromQuery] string session_id)
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var sessionService = new SessionService();
            Session session = sessionService.Get(session_id);

            var customerService = new CustomerService();
            Customer customer = customerService.Get(session.CustomerId);

            return Ok();
        }

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
                SuccessUrl = "https://localhost:7066/order-success",
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
						await addSubscriptionToDb(subscription);
						break;
					case Events.CustomerSubscriptionUpdated:
						var session = stripeEvent.Data.Object as Subscription;
						await updateSubscription(session);
						break;
					case Events.CustomerCreated:
						var customer = stripeEvent.Data.Object as Customer;
						await addCustomerIdToUser(customer);
						break;

					default:
						Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
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
				ReceiptDate = DateTime.Now,
				ReceiptName = "Receipt_" + DateTime.Now,
				ReceiptUrl = result.Charges.Data.FirstOrDefault().ReceiptUrl
			});
		}

		private async Task updateSubscription(Subscription subscription)
		{
			//try
			//{
			//	var subscriptionFromDb = await _subscriberRepository.GetByIdAsync(subscription.Id);
			//	if (subscriptionFromDb != null)
			//	{
			//		subscriptionFromDb.Status = subscription.Status;
			//		subscriptionFromDb.CurrentPeriodEnd = subscription.CurrentPeriodEnd;
			//		await _subscriberRepository.UpdateAsync(subscriptionFromDb);
			//		Console.WriteLine("Subscription Updated");
			//	}
			//}
			//catch (System.Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//	Console.WriteLine("Unable to update subscription");
			//}
		}

		private async Task addCustomerIdToUser(Customer customer)
		{
			//try
			//{
			//	var userFromDb = await _userManager.FindByEmailAsync(customer.Email);
			//	if (userFromDb != null)
			//	{
			//		userFromDb.CustomerId = customer.Id;
			//		await _userManager.UpdateAsync(userFromDb);
			//		Console.WriteLine("Customer Id added to user ");
			//	}
			//}
			//catch (System.Exception ex)
			//{
			//	Console.WriteLine("Unable to add customer id to user");
			//	Console.WriteLine(ex);
			//}
		}

		private async Task addSubscriptionToDb(Subscription subscription)
		{
			//try
			//{
			//	var subscriber = new Subscriber
			//	{
			//		Id = subscription.Id,
			//		CustomerId = subscription.CustomerId,
			//		Status = "active",
			//		CurrentPeriodEnd = subscription.CurrentPeriodEnd
			//	};
			//	await _subscriberRepository.CreateAsync(subscriber);
			//	//You can send the new subscriber an email welcoming the new subscriber
			//}
			//catch (System.Exception ex)
			//{
			//	Console.WriteLine("Unable to add new subscriber to Database");
			//	Console.WriteLine(ex.Message);
			//}
		}
	}
}
