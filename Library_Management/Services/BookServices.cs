namespace Library
{
    public class BookServices
    {
        private readonly IRepo<Book, int> _bookRepo;

        public BookServices(IRepo<Book, int> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Book AddBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null");
                }
                if (string.IsNullOrWhiteSpace(book.name) || string.IsNullOrWhiteSpace(book.author))
                {
                    throw new ArgumentException("Book name and author cannot be empty");
                }
                if (book.author == "Unknown" || book.author == null)
                {
                    throw new ArgumentException("Author cannot be 'Unknown' or null");
                }
                return _bookRepo.Add(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
                throw;
            }
        }

        public Book UpdateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null");
                }
                if (string.IsNullOrWhiteSpace(book.name) || string.IsNullOrWhiteSpace(book.author))
                {
                    throw new ArgumentException("Book name and author cannot be empty");
                }
                if (book.author == "Unknown" || book.author == null)
                {
                    throw new ArgumentException("Author cannot be 'Unknown' or null");
                }
                if (book.id <= 0)
                {
                    throw new ArgumentException("Invalid book ID");
                }

                return _bookRepo.Update(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book: {ex.Message}");
                throw;
            }
        }
        public void DeleteBook(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid book ID");
                }
                _bookRepo.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                throw;
            }
        }
        public Book GetBookById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid book ID");
                }
                return _bookRepo.GetBookById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving book: {ex.Message}");
                throw;
            }
        }
        public List<Book> GetAllBooks()
        {
            try
            {
                return _bookRepo.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all books: {ex.Message}");
                throw;
            }
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(author))
                {
                    throw new ArgumentException("Author name cannot be empty");
                }
                return _bookRepo.GetByAuthor(author);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving books by author: {ex.Message}");
                throw;
            }
        }
        public List<Book> GetBooksByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Book name cannot be empty");
                }
                return _bookRepo.GetByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving books by name: {ex.Message}");
                throw;
            }
        }
       }
    }
