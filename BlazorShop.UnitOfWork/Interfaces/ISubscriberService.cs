namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface ISubscriberService
    {
        Result<SubscriberResponse> GetAll();
        Result<SubscriberResponse> Get(int id);
        RequestResponse AddSubscriber(SubscriberResponse subscriber);
        RequestResponse UpdateSubscriber(SubscriberResponse subscriber);
        RequestResponse DeleteSubscriber(int id);
    }
}
