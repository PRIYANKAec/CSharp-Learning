namespace Library
{
    public class BookLibrary
    {
        private readonly BookServices _bookServices;

        public BookLibrary(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("-----BOOK MANAGEMENT-----");
                Console.WriteLine("1. Add Book\t2. Update Book\t3. Delete Book\t4. View All Books\t5. Search by Author\t6. Search by Name\t7. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        UpdateBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        ViewAllBooks();
                        break;
                    case "5":
                        SearchByAuthor();
                        break;
                    case "6":
                        SearchByName();
                        break;
                    case "7":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        
            private void AddBook()
        {
            var book = new Book();
            book.GetBookFromUser();
            try
            {
                _bookServices.AddBook(book);
                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void UpdateBook()
        {
            Console.Write("Enter Book ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = _bookServices.GetBookById(id);
            if (book != null)
            {
                book.GetBookFromUser();
                try
                {
                    _bookServices.UpdateBook(book);
                    Console.WriteLine("Book updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        private void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                _bookServices.DeleteBook(id);
                Console.WriteLine("Book deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void ViewAllBooks()
        {
            var books = _bookServices.GetAllBooks();
            if (books.Count > 0)
            {
                Console.WriteLine("Books in the library:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books available in the library.");
            }
        }
        private void SearchByAuthor()
        {
            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();
            var books = _bookServices.GetBooksByAuthor(author);
            if (books.Count > 0)
            {
                Console.WriteLine($"Books by {author}:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine($"No books found by author {author}.");
            }
        }
        private void SearchByName()
        {
            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();
            var books = _bookServices.GetBooksByName(name);
            if (books.Count > 0)
            {
                Console.WriteLine($"Books with name {name}:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine($"No books found with name {name}.");
            }
        }
    }
}