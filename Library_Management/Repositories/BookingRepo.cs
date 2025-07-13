namespace Library
{
    public class BookingRepo : IRepo<Booking, int>
    {
        private readonly List<Booking> _bookings;
        private int _nextId;

        public BookingRepo()
        {
            _bookings = new List<Booking>();
            _nextId = 1;
        }

        public Booking Add(Booking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Booking cannot be null");
            }
            item.BookingId = _nextId++;
            _bookings.Add(item);
            return item;
        }

        public Booking Update(Booking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Booking cannot be null");
            }
            var existingBooking = GetById(item.BookingId);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException("Booking not found");
            }
            existingBooking.UserId = item.UserId;
            existingBooking.BookId = item.BookId;
            existingBooking.UserName = item.UserName;
            existingBooking.BookName = item.BookName;
            existingBooking.BorrowDate = item.BorrowDate;
            existingBooking.ReturnDate = item.ReturnDate;
            existingBooking.IsReturned = item.IsReturned;
            return existingBooking;
        }

        public Booking GetById(int id)
        {
            return _bookings.FirstOrDefault(b => b.BookingId == id);
        }

        // Required by IRepo interface - maps to GetById for Booking
        public Booking GetBookById(int id)
        {
            return GetById(id);
        }

        // Required by IRepo interface - searches by book name in bookings
        public List<Booking> GetByName(string name)
        {
            return _bookings.Where(b => b.BookName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Required by IRepo interface - searches by user name in bookings
        public List<Booking> GetByAuthor(string author)
        {
            return _bookings.Where(b => b.UserName.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Booking> GetAll()
        {
            return _bookings;
        }

        public void Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                _bookings.Remove(booking);
            }
            else
            {
                throw new KeyNotFoundException("Booking not found");
            }
        }

        public List<Booking> GetByUserId(int userId)
        {
            return _bookings.Where(b => b.UserId == userId).ToList();
        }

        public List<Booking> GetByBookId(int bookId)
        {
            return _bookings.Where(b => b.BookId == bookId).ToList();
        }

        public List<Booking> GetActiveBorrowings()
        {
            return _bookings.Where(b => !b.IsReturned).ToList();
        }
    }
}
