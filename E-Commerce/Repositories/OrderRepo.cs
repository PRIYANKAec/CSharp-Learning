namespace ECommerce
{
    public class OrderRepo : IRepo<Order, int>
    {
        private List<Order> orders = new List<Order>();

        public void Create(Order order)
        {
            orders.Add(order);
        }

        public void Update(Order order)
        {
            var existingOrder = GetById(order.id);
            if (existingOrder != null)
            {
                existingOrder.quantity = order.quantity;
                existingOrder.totalPrice = order.totalPrice;
                existingOrder.orderDate = order.orderDate;
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                orders.Remove(order);
            }
        }

        public Order GetById(int id)
        {
            return orders.Find(o => o.productId == id);
        }

        public List<Order> GetAll()
        {
            return new List<Order>(orders);
        }
}
}