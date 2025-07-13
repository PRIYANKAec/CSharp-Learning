namespace Library
{
    public class BookingStore : IRepo<Book, int>
    {
        private readonly List<Book> _bookings;

        public BookingStore()
        {
            _bookings = new List<Book>();
        }
        public Book Add(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Booking cannot be null");
            }
            _bookings.Add(item);
            return item;
        }
        public Book Update(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Booking cannot be null");
            }
            var existingBooking = GetBookById(item.id);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException("Booking not found");
            }
            existingBooking.name = item.name;
            existingBooking.author = item.author;
            existingBooking.isbn = item.isbn;
            existingBooking.bookCount = item.bookCount;
            return existingBooking;
        }
        public Book GetBookById(int id)
        {
            return _bookings.FirstOrDefault(b => b.id == id);
        }
        public List<Book> GetByAuthor(string author)
        {
            return _bookings.Where(b => b.author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public List<Book> GetByName(string name)
        {
            return _bookings.Where(b => b.name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public List<Book> GetAll()
        {
            return _bookings;
        }
        public void Delete(int id)
        {
            var booking = GetBookById(id);
            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found");
            }
            _bookings.Remove(booking);
        }
    }
}