namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ECommerce ecommerce = new Ecommerce();
            ecommerce.ecommerceProduct.Run();
            // ecommerce.ecommerceOrder.Run();
        }
    }
}