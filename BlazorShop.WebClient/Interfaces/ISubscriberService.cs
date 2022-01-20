namespace BlazorShop.WebClient.Interfaces
{
    public interface ISubscriberService
    {
        Task<List<SubscriberResponse>> GetSubscribers();
        Task<SubscriberResponse> GetSubscriber(int id);
        Task<RequestResponse> AddSubscriber(SubscriberResponse subscriber);
        Task<RequestResponse> UpdateSubscriber(SubscriberResponse subscriber);
        Task<RequestResponse> DeleteSubscriber(int id);
    }
}
