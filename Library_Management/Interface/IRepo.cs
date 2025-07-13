namespace Library
{
    public interface IRepo<T, K>
    {
        T Add(T item);
        T Update(T item);
        void Delete(K id);

        T GetBookById(K id);
        List<T> GetAll();
        List<T> GetByAuthor(string author);
        List<T> GetByName(string name);
    }
}