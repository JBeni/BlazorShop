namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface ISubscriberService
    {
        List<SubscriberResponse> GetAll();
        SubscriberResponse Get(int id);
        RequestResponse AddSubscriber(SubscriberResponse subscriber);
        RequestResponse UpdateSubscriber(SubscriberResponse subscriber);
        RequestResponse DeleteSubscriber(int id);
    }
}
