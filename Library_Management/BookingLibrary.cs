namespace Library
{
    public class BookingLibrary
    {
        private readonly BookingServices _bookingServices;
        private readonly BookServices _bookServices;
        private readonly UserServices _userServices;

        public BookingLibrary(BookingServices bookingServices, BookServices bookServices, UserServices userServices)
        {
            _bookingServices = bookingServices;
            _bookServices = bookServices;
            _userServices = userServices;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("-----BOOKING MANAGEMENT-----");
                Console.WriteLine("1. Borrow Book\t2. Return Book\t3. View All Bookings\t4. View User's Active Borrowings\t5. View User's Borrowing History\t6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BorrowBook();
                        break;
                    case "2":
                        ReturnBook();
                        break;
                    case "3":
                        ViewAllBookings();
                        break;
                    case "4":
                        ViewUserActiveBorrowings();
                        break;
                    case "5":
                        ViewUserBorrowingHistory();
                        break;
                    case "6":
                        Console.WriteLine("Exiting booking management. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void BorrowBook()
        {
            try
            {
                Console.WriteLine("=== BORROW BOOK ===");
                
                // Show available users
                var users = _userServices.GetAllUsers();
                if (users.Count == 0)
                {
                    Console.WriteLine("No users available. Please add users first.");
                    return;
                }
                
                Console.WriteLine("Available Users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}");
                }
                
                Console.Write("Enter User ID: ");
                int userId = Convert.ToInt32(Console.ReadLine());
                
                // Show available books
                var books = _bookServices.GetAllBooks();
                var availableBooks = books.Where(b => b.bookCount > 0).ToList();
                
                if (availableBooks.Count == 0)
                {
                    Console.WriteLine("No books available for borrowing.");
                    return;
                }
                
                Console.WriteLine("Available Books:");
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"ID: {book.id}, Name: {book.name}, Author: {book.author}, Available: {book.bookCount}");
                }
                
                Console.Write("Enter Book ID: ");
                int bookId = Convert.ToInt32(Console.ReadLine());
                
                _bookingServices.BorrowBook(userId, bookId);
                Console.WriteLine("Book borrowed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error borrowing book: {ex.Message}");
            }
        }

        private void ReturnBook()
        {
            try
            {
                Console.WriteLine("=== RETURN BOOK ===");
                
                Console.Write("Enter User ID: ");
                int userId = Convert.ToInt32(Console.ReadLine());
                
                // Show user's active borrowings
                var activeBorrowings = _bookingServices.GetActiveBorrowingsByUser(userId);
                if (activeBorrowings.Count == 0)
                {
                    Console.WriteLine("No active borrowings found for this user.");
                    return;
                }
                
                Console.WriteLine("Active Borrowings:");
                foreach (var borrowing in activeBorrowings)
                {
                    Console.WriteLine($"Book ID: {borrowing.BookId}, Book Name: {borrowing.BookName}, Borrowed: {borrowing.BorrowDate:yyyy-MM-dd}");
                }
                
                Console.Write("Enter Book ID to return: ");
                int bookId = Convert.ToInt32(Console.ReadLine());
                
                _bookingServices.ReturnBook(userId, bookId);
                Console.WriteLine("Book returned successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error returning book: {ex.Message}");
            }
        }

        private void ViewAllBookings()
        {
            try
            {
                var bookings = _bookingServices.GetAllBookings();
                if (bookings.Count > 0)
                {
                    Console.WriteLine("=== ALL BOOKINGS ===");
                    foreach (var booking in bookings.OrderByDescending(b => b.BorrowDate))
                    {
                        Console.WriteLine(booking);
                    }
                }
                else
                {
                    Console.WriteLine("No bookings found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving bookings: {ex.Message}");
            }
        }

        private void ViewUserActiveBorrowings()
        {
            try
            {
                Console.Write("Enter User ID: ");
                int userId = Convert.ToInt32(Console.ReadLine());
                
                var activeBorrowings = _bookingServices.GetActiveBorrowingsByUser(userId);
                if (activeBorrowings.Count > 0)
                {
                    Console.WriteLine($"=== ACTIVE BORROWINGS FOR USER ID: {userId} ===");
                    foreach (var borrowing in activeBorrowings)
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                else
                {
                    Console.WriteLine("No active borrowings found for this user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving active borrowings: {ex.Message}");
            }
        }

        private void ViewUserBorrowingHistory()
        {
            try
            {
                Console.Write("Enter User ID: ");
                int userId = Convert.ToInt32(Console.ReadLine());
                
                var borrowingHistory = _bookingServices.GetBorrowingHistoryByUser(userId);
                if (borrowingHistory.Count > 0)
                {
                    Console.WriteLine($"=== BORROWING HISTORY FOR USER ID: {userId} ===");
                    foreach (var borrowing in borrowingHistory.OrderByDescending(b => b.BorrowDate))
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                else
                {
                    Console.WriteLine("No borrowing history found for this user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving borrowing history: {ex.Message}");
            }
        }
    }
}
