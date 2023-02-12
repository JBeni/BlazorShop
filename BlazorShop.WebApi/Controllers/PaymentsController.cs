// <copyright file="PaymentsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Payments.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class PaymentsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsController"/> class.
        /// </summary>
        /// <param name="configuration">The instance of the <see cref="IConfiguration"/> to use.</param>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public PaymentsController(IConfiguration configuration, IMediator mediator)
            : base(mediator)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Create the subscription session.
        /// </summary>
        /// <param name="req">The req data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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
                },
            };

            try
            {
                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return this.Ok(session.Url);
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Cancel the stripe subscription.
        /// </summary>
        /// <param name="stripeSubscriptionCreationId">The id of the stripe created subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("cancel-subscription/{stripeSubscriptionCreationId}")]
        public async Task<IActionResult> CancelSubscriptionSession(string stripeSubscriptionCreationId)
        {
            try
            {
                var subscriptionService = new SubscriptionService();
                subscriptionService.Cancel(stripeSubscriptionCreationId);

                await this.Mediator.Send(new UpdateSubscriberStatusCommand
                {
                    StripeSubscriberSubscriptionId = stripeSubscriptionCreationId,
                });

                return this.Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Updating the stripe subscription.
        /// </summary>
        /// <param name="req">The req data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("update-subscription")]
        public async Task<IActionResult> UpdateSubscriptionSession([FromBody] UpdateSubscriberCommand req)
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.Cancel(req.StripeSubscriberSubscriptionId);

            await this.Mediator.Send(new UpdateSubscriberStatusCommand
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
                },
            };

            try
            {
                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return this.Ok(session.Url);
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Create the checkout operation.
        /// </summary>
        /// <param name="cartItems">The cart items.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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

                            // Images = new List<string> { x.Image }
                        },
                    },
                    Quantity = x.Amount,
                }));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7066/order-success/success-made",
                CancelUrl = "https://localhost:7066/carts",
            };

            #pragma warning disable CS1587 // XML comment is not placed on a valid language element
            /**
            * https://localhost:7066/order-success
            * SuccessUrl = https://localhost:44351/api/Payments/checkout-response?session_id={CHECKOUT_SESSION_ID}
            */
            var service = new SessionService();
            #pragma warning restore CS1587 // XML comment is not placed on a valid language element

            Session session = service.Create(options);
            return this.Ok(session.Url);
        }

        /// <summary>
        /// Activate the background webhook.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(this.HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    this.Request.Headers["Stripe-Signature"],
                    this.Configuration["StripeSettings:WebHookKey"]);

                // Handle the event
                switch (stripeEvent.Type)
                {
                    case Events.CheckoutSessionCompleted:
                        await this.CompleteAcceptCheckout(stripeEvent);
                        break;
                    case Events.CustomerSubscriptionCreated:
                        var subscription = stripeEvent.Data.Object as Subscription;
                        var service = new InvoiceService();
                        var invoiceData = service.Get(subscription.LatestInvoiceId);

                        await this.Mediator.Send(new UpdateCreatedSubscriberCommand
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

                        await this.Mediator.Send(new UpdateCreatedSubscriberCommand
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

                return this.Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Complet the checkout.
        /// </summary>
        /// <param name="stripeEvent">The stripe event.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task CompleteAcceptCheckout(Event stripeEvent)
        {
            var sessionData = stripeEvent.Data.Object as Session;
            var service = new PaymentIntentService();
            var result = service.Get(sessionData.PaymentIntentId);

            var sessionService = new SessionService();
            StripeList<LineItem> lineItems = sessionService.ListLineItems(sessionData.Id);

            List<InvoiceResponse> items = new ();
            foreach (var item in lineItems.Data)
            {
                var invoice = new InvoiceResponse
                {
                    Name = item.Description,
                    AmountSubTotal = Convert.ToInt32(item.AmountSubtotal) / 100,
                    AmountTotal = Convert.ToInt32(item.AmountTotal) / 100,
                    Quantity = Convert.ToInt32(item.Quantity),
                };
                items.Add(invoice);
            }

            var orderCommand = new CreateOrderCommand
            {
                UserEmail = sessionData.CustomerDetails.Email,
                OrderDate = DateTime.Now,
                LineItems = JsonSerializer.Serialize(items),
                AmountTotal = Convert.ToInt32(sessionData.AmountTotal) / 100,
            };

            await this.Mediator.Send(orderCommand);
            await this.Mediator.Send(new CreateReceiptCommand
            {
                UserEmail = sessionData.CustomerDetails.Email,
                ReceiptDate = DateTime.Now,
                ReceiptName = "Receipt Nr. " + Guid.NewGuid(),
                ReceiptUrl = result.Charges.Data.FirstOrDefault().ReceiptUrl,
            });
        }
    }
}
