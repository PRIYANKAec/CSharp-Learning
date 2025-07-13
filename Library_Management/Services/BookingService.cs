namespace Library
{
    public class BookingServices
    {
        private readonly IRepo<Book, int> _bookRepo;
        private readonly IUserRepo<User, int> _userRepo;
        private readonly IRepo<Booking, int> _bookingRepo;

        public BookingServices(IRepo<Book, int> bookRepo, IUserRepo<User, int> userRepo, IRepo<Booking, int> bookingRepo)
        {
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _bookingRepo = bookingRepo;
        }

        public void BorrowBook(int userId, int bookId)
        {
            var user = _userRepo.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var book = _bookRepo.GetBookById(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            if (book.bookCount <= 0)
            {
                throw new InvalidOperationException("Book is not available for borrowing");
            }

            // Check if user already borrowed this book
            var existingBorrowing = GetActiveBorrowingsByUser(userId)
                .FirstOrDefault(b => b.BookId == bookId);
            if (existingBorrowing != null)
            {
                throw new InvalidOperationException("User has already borrowed this book");
            }

            // Create booking record
            var booking = new Booking
            {
                UserId = userId,
                BookId = bookId,
                UserName = user.UserName,
                BookName = book.name,
                BorrowDate = DateTime.Now,
                IsReturned = false
            };

            _bookingRepo.Add(booking);

            // Update book count
            book.bookCount--;
            _bookRepo.Update(book);

            // Update user's borrowed books
            user.BorrowedBooks.Add(book.name);
            user.BorrowedBookCount++;
            _userRepo.Update(user);
        }

        public void ReturnBook(int userId, int bookId)
        {
            var user = _userRepo.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var book = _bookRepo.GetBookById(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            // Find active borrowing
            var borrowing = GetActiveBorrowingsByUser(userId)
                .FirstOrDefault(b => b.BookId == bookId);
            if (borrowing == null)
            {
                throw new InvalidOperationException("No active borrowing found for this book and user");
            }

            // Update booking record
            borrowing.ReturnDate = DateTime.Now;
            borrowing.IsReturned = true;
            _bookingRepo.Update(borrowing);

            // Update book count
            book.bookCount++;
            _bookRepo.Update(book);

            // Update user's borrowed books
            user.BorrowedBooks.Remove(book.name);
            user.BorrowedBookCount--;
            _userRepo.Update(user);
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepo.GetAll();
        }

        public List<Booking> GetActiveBorrowingsByUser(int userId)
        {
            return _bookingRepo.GetAll()
                .Where(b => b.UserId == userId && !b.IsReturned)
                .ToList();
        }

        public List<Booking> GetBorrowingHistoryByUser(int userId)
        {
            return _bookingRepo.GetAll()
                .Where(b => b.UserId == userId)
                .ToList();
        }
    }
}
