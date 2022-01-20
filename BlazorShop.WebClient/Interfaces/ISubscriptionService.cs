namespace BlazorShop.WebClient.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionResponse>> GetSubscriptions();
        Task<SubscriptionResponse> GetSubscription(int id);
        Task<RequestResponse> AddSubscription(SubscriptionResponse subscription);
        Task<RequestResponse> UpdateSubscription(SubscriptionResponse subscription);
        Task<RequestResponse> DeleteSubscription(int id);
    }
}
