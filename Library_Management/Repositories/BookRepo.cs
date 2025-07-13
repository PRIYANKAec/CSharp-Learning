namespace Library
{
    public class BookRepo : IRepo<Book, int>
    {
        private List<Book> _books = new List<Book>();

        public Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.id == id);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public List<Book> GetByAuthor(string author)
        {
            return _books.Where(b => b.author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> GetByName(string name)
        {
            return _books.Where(b => b.name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Book Update(Book book)
        {
            var existingBook = GetBookById(book.id);
            if (existingBook != null)
            {
                existingBook.name = book.name;
                existingBook.author = book.author;
                existingBook.isbn = book.isbn;
                existingBook.bookCount = book.bookCount;
            }
            return existingBook;
        }

        public void Delete(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

    }
}