namespace ECommerce
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public List<Order> orders { get; set; }

        public void GetUserFromInput()
        {
            Console.WriteLine("Enter User ID:");
            userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Name:");
            userName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            password = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"User ID: {userId}, User Name: {userName}";
        }
    }
}