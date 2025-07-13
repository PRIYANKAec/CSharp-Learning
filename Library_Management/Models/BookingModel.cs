namespace Library
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        public override string ToString()
        {
            var status = IsReturned ? "Returned" : "Borrowed";
            var returnInfo = IsReturned ? $", Returned: {ReturnDate?.ToString("yyyy-MM-dd")}" : "";
            return $"BookingID: {BookingId}, User: {UserName}, Book: {BookName}, Borrowed: {BorrowDate:yyyy-MM-dd}{returnInfo}, Status: {status}";
        }
    }
}
