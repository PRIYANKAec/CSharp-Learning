namespace ECommerce
{
    public class Ecommerce
    {
        IRepo<Product, int> productRepo = new ProductRepo();
        ProductServices productServices = new ProductServices(productRepo);
        EcommerceProduct ecommerceProduct = new EcommerceProduct(productServices);

        // IRepo<Order> orderRepo = new OrderRepo();
        // OrderServices orderServices = new OrderServices(orderRepo); 
        // EcommerceOrder ecommerceOrder = new EcommerceOrder(orderServices);


    }
}