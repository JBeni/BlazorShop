namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface ISubscriptionService
    {
        List<SubscriptionResponse> GetAll();
        SubscriptionResponse Get(int id);
        RequestResponse AddSubscription(SubscriptionResponse subscription);
        RequestResponse UpdateSubscription(SubscriptionResponse subscription);
        RequestResponse DeleteSubscription(int id);
    }
}
