namespace BlazorShop.WebClient.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionResponse>> GetSubscriptions();
        Task<SubscriptionResponse> GetSubscription(int id);
        Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription);
        Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription);
        Task<RequestResponse> DeleteSubscription(int id);
    }
}
