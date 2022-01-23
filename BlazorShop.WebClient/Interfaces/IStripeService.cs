namespace BlazorShop.WebClient.Interfaces
{
    public interface IStripeService
    {
        Task CancelMembership(string stripeSubscriptionCreationId);
    }
}
