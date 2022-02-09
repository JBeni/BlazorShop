namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface ISubscriptionService
    {
        Result<SubscriptionResponse> GetAll();
        Result<SubscriptionResponse> Get(int id);
        RequestResponse AddSubscription(SubscriptionResponse subscription);
        RequestResponse UpdateSubscription(SubscriptionResponse subscription);
        RequestResponse DeleteSubscription(int id);
    }
}
