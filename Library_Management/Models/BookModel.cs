namespace Library
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public int bookCount {get; set;}

        public void GetBookFromUser()
        {
            Console.WriteLine("Enter Book ID:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Book Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Author Name:");
            author = Console.ReadLine();
            Console.WriteLine("Enter ISBN:");
            isbn = Console.ReadLine();
            Console.WriteLine("Enter Book Count:");
            bookCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Book details entered successfully. and Added to the library.");
        }

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Author: {author}, ISBN: {isbn}";
        }
    }
}