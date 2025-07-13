namespace Library
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public List<string> BorrowedBooks { get; set; }
        public int BorrowedBookCount { get; set; }

        public void GetUSerFromInput()
        {
            Console.WriteLine("Enter USerID:");
            UserId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Name:");
            UserName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            password = Console.ReadLine();
            BorrowedBooks = new List<string>();
            BorrowedBookCount = 0;
            Console.WriteLine("User details entered successfully.");
        }

        public override string ToString()
        {
            return $"UserID: {UserId}, UserName: {UserName}, BorrowedBooks: {BorrowedBooks}, BorrowedBookCount: {BorrowedBookCount}";
        }
    }
}