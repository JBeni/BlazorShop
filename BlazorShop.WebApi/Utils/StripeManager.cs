namespace BlazorShop.WebApi.Utils
{
    public class StripeManager
    {
/*
        private readonly ILogger _logger;
        private readonly IAKVService _akv;
        private readonly string _stripeKeyLocation;
        private readonly string _stripeWebHookKey;
        public StripeManager(ILogger<StripeManager> logger,
            IAKVService akv, IConfiguration configuration)
        {
            _stripeKeyLocation = configuration.GetSection("Stripe").GetValue<string>("StripeKeyLocation");
            _stripeWebHookKey = configuration.GetSection("Stripe").GetValue<string>("StripeWebhookKey");
            _logger = logger;
            _akv = akv;
        }

        public APIResultModel VerifySubRequest(StripeBillingRequest subReq, bool checkDb = false)
        {
            APIResultModel result = new(true);
            if (subReq == null)
            {
                result.Success = false;
                result.Message = "Subscription Request cannot be empty.";
            }
            else if (string.IsNullOrWhiteSpace(subReq.BillingName))
            {
                result.Success = false;
                result.Message = "Billing Name is required";
            }
            else if (string.IsNullOrWhiteSpace(subReq.BillingEmail))
            {
                result.Success = false;
                result.Message = "Billing Email is required";
            }
            else if (string.IsNullOrWhiteSpace(subReq.PaymentMethod))
            {
                result.Success = false;
                result.Message = "Billing payment ID is required";
            }
            else if (string.IsNullOrWhiteSpace(subReq.Price))
            {
                result.Success = false;
                result.Message = "Billing Plan ID is required";
            }
            else if (checkDb)
            {
            }
            return result;
        }

        public async Task<APIResultModel> ActivateSubscriptionAsync(StripeBillingRequest subReq)
        {
            APIResultModel result = VerifySubRequest(subReq, false);
            if (!result.Success)
            {
                return result;
            }
            StripeConfiguration.ApiKey = await _akv.GetKeyVaultSecretAsync(_stripeKeyLocation);
            string customerID = await CheckIfCustomerExistsorCreateOneAsync(subReq);
            await UpdateCustomersDefaultPaymentIDAsync(customerID, subReq.PaymentMethod);
            return await CreateSubscriptionAsync(customerID, subReq);
        }

        private async Task<string> CheckIfCustomerExistsorCreateOneAsync(StripeBillingRequest subReq)
        {
            DBStripeCustomerModel existingCustomer = null;
            if (existingCustomer == null)
            {
                return await CreateCustomerAsync(subReq);
            }
            if (existingCustomer.PaymentMethod != subReq.PaymentMethod)
            {
                existingCustomer.PaymentMethod = subReq.PaymentMethod;
            }
            return existingCustomer.ClientID;
        }

        private async Task<string> CreateCustomerAsync(StripeBillingRequest subReq)
        {
            var options = new CustomerCreateOptions
            {
                Email = subReq.BillingEmail,
                Name = subReq.BillingName,
            };
            var service = new CustomerService();
            var customer = await service.CreateAsync(options);
            return customer.Id;
        }

        private static async Task UpdateCustomersDefaultPaymentIDAsync(string customerID, string PaymentMethod)
        {
            var options = new PaymentMethodAttachOptions
            {
                Customer = customerID,
            };
            var service = new PaymentMethodService();
            var paymentMethod = await service.AttachAsync(PaymentMethod, options);
            var customerOptions = new CustomerUpdateOptions
            {
                InvoiceSettings = new CustomerInvoiceSettingsOptions
                {
                    DefaultPaymentMethod = paymentMethod.Id,
                },
            };
            var customerService = new CustomerService();
            await customerService.UpdateAsync(customerID, customerOptions);
        }

        private async Task<APIResultModel> CreateSubscriptionAsync(string customerID, StripeBillingRequest subReq)
        {
            APIResultModel result = new(true);
            var subscriptionOptions = new SubscriptionCreateOptions
            {
                Customer = customerID,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = subReq.Price,
                    },
                },
            };
            subscriptionOptions.AddExpand("latest_invoice.payment_intent");
            var subscriptionService = new SubscriptionService();
            try
            {
                Subscription subscription = await subscriptionService.CreateAsync(subscriptionOptions);
                result.Message = "Subscription created Successfully";
            }
            catch (StripeException e)
            {
                Console.WriteLine($"Failed to create subscription.{e}");
                result.Success = false;
                result.Message = "Error processing your payment.";
            }
            return result;
        }
*/
    }
}
