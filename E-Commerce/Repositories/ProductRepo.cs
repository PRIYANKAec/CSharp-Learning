using System.Collections.Generic;

namespace ECommerce
{
    public class ProductRepo : IRepo<Product, int>
    {
        private List<Product> _products = new List<Product>();

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.id);
            if (existingProduct != null)
            {
                existingProduct.productName = product.productName;
                existingProduct.description = product.description;
                existingProduct.price = product.price;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public Product GetById(int id)
        {
            return _products.Find(p => p.id == id);
        }

        public List<Product> GetAll()
        {
            return new List<Product>(_products);
        }
    }
}