namespace BlazorShop.UnitOfWork.Repositories
{
    public class UnitOfWorkPattern : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IMusicRepository MusicRepository { get; }

        public UnitOfWorkPattern(ApplicationDbContext context,
                          IMusicRepository musicRepository)
        {
            _context = context;

            MusicRepository = musicRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
