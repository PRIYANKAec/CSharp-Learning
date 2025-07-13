namespace Library
{
    public interface IUserRepo<T, K>
    {
        T Add(T item);
        T Update(T item);
        void Delete(K id);

        T GetUserById(K id);
        List<T> GetAll();
        List<T> GetByName(string name);
    }
}