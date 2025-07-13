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

            while(true)
            {
                Console.WriteLine("-----Welcome to the Library Management System-----");
                Console.WriteLine("1. Manage Users\t2. Manage Books\t3. Exit");
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