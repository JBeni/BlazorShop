namespace BlazorShop.WebClient.Interfaces
{
    public interface ISubscriberService
    {
        Task<List<SubscriberResponse>> GetSubscribers();
        Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId);
        Task<SubscriberResponse> GetUserSubscriber(int userId);
        Task<RequestResponse> AddSubscriber(SubscriberResponse subscriber);
        Task<RequestResponse> UpdateSubscriber(SubscriberResponse subscriber);
        Task<RequestResponse> DeleteSubscriber(int id);
    }
}
