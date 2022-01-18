namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
