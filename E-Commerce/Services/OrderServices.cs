namespace ECommerce
{
    public class OrderServices
    {
        private readonly IRepo<Order, int> _orderRepo;

        public OrderServices(IRepo<Order, int> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void Create(Order order)
        {
            try
            {
                if (order == null)
                {
                    throw new System.ArgumentNullException(nameof(order), "Order cannot be null");
                }
                if (order.quantity <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(order.quantity), "Quantity must be greater than zero");
                }
                if (order.totalPrice <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(order.totalPrice), "Total price must be greater than zero");
                }

                _orderRepo.Create(order);
                Console.WriteLine("Order created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the order: {ex.Message}");
                throw;
            }
        }

        public void Update(Order order)
        {
            try
            {
                if (order == null)
                {
                    throw new System.ArgumentNullException(nameof(order), "Order cannot be null");
                }
                if (order.quantity <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(order.quantity), "Quantity must be greater than zero");
                }
                if (order.totalPrice <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(order.totalPrice), "Total price must be greater than zero");
                }

                _orderRepo.Update(order);
                System.Console.WriteLine("Order updated successfully.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occurred while updating the order.");
                throw;
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                _orderRepo.Delete(id);
                System.Console.WriteLine("Order deleted successfully.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occurred while deleting the order.");
                throw;
            }
        }

        public Order GetById(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
            {
                throw new System.ArgumentException("Order not found", nameof(id));
            }
            return order;
        }

        public List<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }
    }
}