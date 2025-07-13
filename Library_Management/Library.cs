using System.Net.NetworkInformation;

namespace Library
{
    public class LibraryMain
    {
        public static void Main(string[] args)
        {
            IRepo<Book, int> bookRepo = new BookRepo();
            BookServices bookServices = new BookServices(bookRepo);
            BookLibrary library = new BookLibrary(bookServices);

            IUserRepo<User, int> userRepo = new UserRepo();
            UserServices userServices = new UserServices(userRepo);
            UserLibrary userLibrary = new UserLibrary(userServices);

            IRepo<Booking, int> bookingRepo = new BookingRepo();
            BookingServices bookingServices = new BookingServices(bookRepo, userRepo, bookingRepo);
            BookingLibrary bookingLibrary = new BookingLibrary(bookingServices, bookServices, userServices);

            bookRepo.Add(new Book { id = 1, name = "C# in Depth", author = "Jon Skeet", isbn = "978-1617294532", bookCount = 5 });
            bookRepo.Add(new Book { id = 2, name = "Clean Code", author = "Robert C. Martin", isbn = "978-0132350884", bookCount = 3 });
            bookRepo.Add(new Book { id = 3, name = "The Pragmatic Programmer", author = "Andrew Hunt", isbn = "978-0201616224", bookCount = 2 });

            userRepo.Add(new User { UserId = 1, UserName = "Alice", password = "alice123", BorrowedBooks = new List<string> { "C# in Depth" }, BorrowedBookCount = 1 });
            userRepo.Add(new User { UserId = 2, UserName = "Bob", password = "bob123", BorrowedBooks = new List<string>(), BorrowedBookCount = 0 });
            userRepo.Add(new User { UserId = 3, UserName = "Charlie", password = "charlie123", BorrowedBooks = new List<string>(), BorrowedBookCount = 0 });

            // Add a sample booking record for Alice
            bookingRepo.Add(new Booking 
            { 
                BookingId = 1, 
                UserId = 1, 
                BookId = 1, 
                UserName = "Alice", 
                BookName = "C# in Depth", 
                BorrowDate = DateTime.Now.AddDays(-5), 
                IsReturned = false 
            });

            while (true)
            {
                Console.WriteLine("-----Welcome to the Library Management System-----");
                Console.WriteLine("1. Manage Users\t2. Manage Books\t3. Manage Bookings\t4. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        userLibrary.Run();
                        break;
                    case "2":
                        library.Run();
                        break;
                    case "3":
                        bookingLibrary.Run();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}