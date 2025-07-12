namespace ECommerce
{
    public class OrderServices : OrderRepo
    {
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

                base.Create(order);
                System.Console.WriteLine("Order created successfully.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("An error occurred while creating the order.");
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

                base.Update(order);
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
                base.Delete(id);
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
            var order = base.GetById(id);
            if (order == null)
            {
                throw new System.ArgumentException("Order not found", nameof(id));
            }
            return order;
        }
    }
}