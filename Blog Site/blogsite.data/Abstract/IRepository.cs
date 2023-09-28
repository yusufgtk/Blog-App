namespace blogsite.data.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}