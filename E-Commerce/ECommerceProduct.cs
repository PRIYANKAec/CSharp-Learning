namespace ECommerce
{
    public class EcommerceProduct
    {
        List<Product> Product = new List<Product>
           {
               new Product { Id = 1, Name = "Laptop", Price = 999.99M },
               new Product { Id = 2, Name = "Smartphone", Price = 499.99M },
               new Product { Id = 3, Name = "Tablet", Price = 299.99M },
               new Product { Id = 4, Name = "Smartwatch", Price = 199.99M },
               new Product { Id = 5, Name = "Headphones", Price = 99.99M },
               new Product { Id = 6, Name = "Bluetooth Speaker", Price = 79.99M } 
           };

        void Run()
        {
           while(true)
           {
            System.Console.WriteLine("Welcome to E-Commerce Shop!");
            System.Console.WriteLine("Choose choice 1: Add Product 2: Update Product 3: Delete Product 4: View Products 5: Exit");
            var choice = System.Console.ReadLine();
            switch(choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    ViewProducts();
                    break;
                case "5":
                    System.Console.WriteLine("Exiting the application.");
                    return;
                default:
                    System.Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
           }

        }

        private void AddProduct()
        {
            var product = new Product();
            System.Console.WriteLine("Enter Product Name:");
            product.productName = System.Console.ReadLine();
            System.Console.WriteLine("Enter Product Description:");
            product.description = System.Console.ReadLine();
            System.Console.WriteLine("Enter Product Price:");
            product.price = double.Parse(System.Console.ReadLine());

            productServices.Create(product);
            System.Console.WriteLine("Product added successfully.");
        }

        private void UpdateProduct()
        {
            System.Console.WriteLine("Enter Product ID to Update:");
            int id = int.Parse(System.Console.ReadLine());
            var product = productRepo.GetById(id);
            if (product == null)
            {
                System.Console.WriteLine("Product not found.");
                return;
            }

            System.Console.WriteLine("Enter New Product Name:");
            product.productName = System.Console.ReadLine();
            System.Console.WriteLine("Enter New Product Description:");
            product.description = System.Console.ReadLine();
            System.Console.WriteLine("Enter New Product Price:");
            product.price = double.Parse(System.Console.ReadLine());

            productServices.Update(product);
            System.Console.WriteLine("Product updated successfully.");
        }

        private void DeleteProduct()
        {
            System.Console.WriteLine("Enter Product ID to Delete:");
            int id = int.Parse(System.Console.ReadLine());
            productServices.Delete(id);
            System.Console.WriteLine("Product deleted successfully.");
        }

        private void ViewProducts()
        {
            var products = productServices.GetAll();
            if (products.Count == 0)
            {
                System.Console.WriteLine("No products available.");
                return;
            }

            foreach (var product in products)
            {
                System.Console.WriteLine($"ID: {product.id}, Name: {product.productName}, Description: {product.description}, Price: {product.price}");
            }
            System.Console.WriteLine("Total Products: " + products.Count);
        }
    }
}