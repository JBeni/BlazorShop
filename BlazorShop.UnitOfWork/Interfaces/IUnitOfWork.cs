namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository MusicRepository { get; }

        int Commit();
    }
}
