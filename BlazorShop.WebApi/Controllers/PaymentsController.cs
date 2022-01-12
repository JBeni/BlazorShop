namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = "User, Default")]
    public class PaymentsController : ApiControllerBase
    {
        public PaymentsController()
        {
        }

        [HttpPost("process")]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "04-234567"

            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                //Amount = HttpContext.Session.GetLong("Amount"),
                //Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "USD",
                Description = "Buying Flowers",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,

            };
            var service = new ChargeService();
            Charge charge = service.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                //ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                //ViewBag.BalanceTxId = BalanceTransactionId;
                //ViewBag.Customer = customer.Name;
                //return View();
            }

            return Ok();
        }

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
    }
}
