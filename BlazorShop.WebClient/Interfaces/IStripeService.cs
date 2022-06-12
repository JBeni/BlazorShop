namespace BlazorShop.WebClient.Interfaces
{
    public interface IStripeService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task CancelMembership(string stripeSubscriptionCreationId);
    }
}
