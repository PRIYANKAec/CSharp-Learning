namespace ECommerce
{
    public interface IRepo<T, K>
    {
        void Create(T item);
        void Update(T item);
        void Delete(K id);

        T GetById(K id);
        List<T> GetAll();
    }
}