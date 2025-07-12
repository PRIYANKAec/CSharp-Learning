namespace ECommerce
{
    public class Order
    {
        public int productId { get; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
        public DateTime orderDate { get; }
    }
}