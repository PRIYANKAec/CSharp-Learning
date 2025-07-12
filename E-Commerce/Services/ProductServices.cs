namespace ECommerce
{
    public class ProductServices
    {
        private readonly IRepo<Product, int> _productRepo;

        public ProductServices(IRepo<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }

        public void Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new System.ArgumentNullException(nameof(product), "Product cannot be null");
                }
                if (string.IsNullOrWhiteSpace(product.productName))
                {
                    throw new System.ArgumentException("Product name cannot be empty", nameof(product.productName));
                }
                if (product.price <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(product.price), "Price must be greater than zero");
                }

                _productRepo.Create(product);
                System.Console.WriteLine("Product created successfully.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occurred while creating the product.");
                throw;
            }
        }

     public void Update(Product product)
     {
        try
        {
            if (product == null)
            {
                throw new System.ArgumentNullException(nameof(product), "Product cannot be null");
            }
            if (string.IsNullOrWhiteSpace(product.productName))
            {
                throw new System.ArgumentException("Product name cannot be empty", nameof(product.productName));
            }
            if (product.price <= 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(product.price), "Price must be greater than zero");
            }

            _productRepo.Update(product);
            System.Console.WriteLine("Product updated successfully.");
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("An error occurred while updating the product.");
            throw;
        }
     }

     public void Delete(int id)
     {
        try
        {
            var product = _productRepo.GetById(id);
            if (product == null)
            {
                throw new System.ArgumentException("Product not found", nameof(id));
            }

            _productRepo.Delete(id);
            System.Console.WriteLine("Product deleted successfully.");
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("An error occurred while deleting the product.");
            throw;
        }
     }

     public Product GetById(int id)
     {
        try{
            var product = _productRepo.GetById(id);
            if (product == null)
            {
                throw new System.ArgumentException("Product not found", nameof(id));
            }
            return product;
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("An error occurred while retrieving the product.");
            throw;       

        }
     }
        public List<Product> GetAll()
        {
            try
            {
                return _productRepo.GetAll();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occurred while retrieving all products.");
                throw;
            }
        }
    }
}