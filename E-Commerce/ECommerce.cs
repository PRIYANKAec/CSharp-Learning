namespace ECommerce
{
    public class Ecommerce
    {
        public void Run()
        {
            IRepo<Product, int> productRepo = new ProductRepo();
            ProductServices productServices = new ProductServices(productRepo);
            EcommerceProduct ecommerceProduct = new EcommerceProduct(productServices);

            IRepo<Order, int> orderRepo = new OrderRepo();
            OrderServices orderServices = new OrderServices(orderRepo);
            EcommerceOrder ecommerceOrder = new EcommerceOrder(orderServices);

            Console.WriteLine("Welcome to the E-Commerce Application!");
            Console.WriteLine("1- Manage Products");
            Console.WriteLine("2- Manage Orders");
            Console.Write("Please select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ecommerceProduct.Run();
                    break;
                case "2":
                    ecommerceOrder.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}