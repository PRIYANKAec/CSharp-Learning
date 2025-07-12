namespace ECommerce
{
    public class User
    {
        public int userId { get; }
        public string userName { get; }
        public string password { get; }
        List<Order> orders { get; }
    }
}