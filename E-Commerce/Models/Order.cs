namespace ECommerce
{
    public class Order
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
        public DateTime orderDate { get; set; }

        public void GetOrderFromUser()
        {
            Console.WriteLine("Enter Product ID:");
            productId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Quantity:");
            quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Total Price:");
            totalPrice = Convert.ToDouble(Console.ReadLine());
            orderDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Order ID: {id}, Product ID: {productId}, Quantity: {quantity}, Total Price: {totalPrice}, Order Date: {orderDate}";
        }
    }
}