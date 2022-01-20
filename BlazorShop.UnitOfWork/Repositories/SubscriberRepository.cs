namespace BlazorShop.UnitOfWork.Repositories
{
    public class SubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
