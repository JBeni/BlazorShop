namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository MusicRepository { get; }
        ISubscriberRepository SubscriberRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }

        int Commit();
    }
}
