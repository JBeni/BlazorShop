namespace BlazorShop.UnitOfWork.Repositories
{
    public class MusicRepository : GenericRepository<Music>, IMusicRepository
    {
        public MusicRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
