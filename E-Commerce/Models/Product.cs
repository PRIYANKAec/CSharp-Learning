namespace ECommerce
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public void GetProductFromUser()
        {
            Console.WriteLine("Enter Product ID:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Name:");
            productName = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            description = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            price = Convert.ToDouble(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"Product ID: {id}, Name: {productName}, Description: {description}, Price: {price}";
        }
    }
}