namespace ECommerce
{
    public class EcommerceProduct
    {
        private readonly ProductServices _productService;
        public EcommerceProduct(ProductServices productServices)
        {
            _productService = productServices;
            _productService.Create(new Product { id = 1, productName = "Laptop", description= "Laptop", price = 999 });
            _productService.Create(new Product { id = 2, productName = "Smartphone", description= "Smartphone", price = 499.99 });
            _productService.Create(new Product { id = 3, productName = "Tablet", description= "Tablet", price = 299.99 });
            _productService.Create(new Product { id = 4, productName = "Smartwatch", description= "Smartwatch", price = 199.99 });
            _productService.Create(new Product { id = 5, productName = "Headphones", description= "Headphones", price = 99.99 });
            _productService.Create(new Product { id = 6, productName = "Bluetooth Speaker", description= "Bluetooth Speaker", price = 79.99 });
        }


        public void Run()
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
            product.GetProductFromUser();
            _productService.Create(product);
            System.Console.WriteLine("Product added successfully.");
        }

        private void UpdateProduct()
        {
            System.Console.WriteLine("Enter Product ID to Update:");
            int id = int.Parse(System.Console.ReadLine());
            var product = _productService.GetById(id);
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

            _productService.Update(product);
            System.Console.WriteLine("Product updated successfully.");
        }

        private void DeleteProduct()
        {
            System.Console.WriteLine("Enter Product ID to Delete:");
            int id = int.Parse(System.Console.ReadLine());
            _productService.Delete(id);
            System.Console.WriteLine("Product deleted successfully.");
        }

        private void ViewProducts()
        {
            var products = _productService.GetAll();
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