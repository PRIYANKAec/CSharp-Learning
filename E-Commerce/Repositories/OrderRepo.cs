namespace ECommerce
{
    public class OrderRepo : IRepo<Order, int>
    {
        private List<Order> _orders = new List<Order>();

        public void Create(Order order)
        {
            _orders.Add(order);
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
                _orders.Remove(order);
            }
        }

        public Order GetById(int id)
        {
            return _orders.Find(o => o.id == id);
        }

        public List<Order> GetAll()
        {
            return new List<Order>(_orders);
        }
}
}