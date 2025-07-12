namespace ECommerce
{
    public class EcommerceOrder
    {
        private readonly OrderServices _orderService;
        
        public EcommerceOrder(OrderServices orderService)
        {
            _orderService = orderService;
            // Pre-populate with some sample orders
            _orderService.Create(new Order { id = 1, productId = 1, quantity = 2, totalPrice = 1998, orderDate = DateTime.Now.AddDays(-5) });
            _orderService.Create(new Order { id = 2, productId = 2, quantity = 1, totalPrice = 499.99, orderDate = DateTime.Now.AddDays(-3) });
            _orderService.Create(new Order { id = 3, productId = 3, quantity = 3, totalPrice = 899.97, orderDate = DateTime.Now.AddDays(-1) });
        }

        public void Run()
        {
            while (true)
            {
                System.Console.WriteLine("\n=== E-Commerce Order Management ===");
                System.Console.WriteLine("Choose an option:");
                System.Console.WriteLine("1: Add Order");
                System.Console.WriteLine("2: Update Order");
                System.Console.WriteLine("3: Delete Order");
                System.Console.WriteLine("4: View Orders");
                System.Console.WriteLine("5: View Order by ID");
                System.Console.WriteLine("6: Exit");
                System.Console.Write("Enter your choice: ");
                
                var choice = System.Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddOrder();
                        break;
                    case "2":
                        UpdateOrder();
                        break;
                    case "3":
                        DeleteOrder();
                        break;
                    case "4":
                        ViewAllOrders();
                        break;
                    case "5":
                        ViewOrderById();
                        break;
                    case "6":
                        System.Console.WriteLine("Exiting the Order Management System.");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void AddOrder()
        {
            try
            {
                var order = new Order();
                System.Console.WriteLine("\n--- Add New Order ---");
                
                // Generate new ID
                var existingOrders = _orderService.GetAll();
                order.id = existingOrders.Count > 0 ? existingOrders.Max(o => o.id) + 1 : 1;
                
                order.GetOrderFromUser();
                _orderService.Create(order);
                System.Console.WriteLine($"Order added successfully with ID: {order.id}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error adding order: {ex.Message}");
            }
        }

        private void UpdateOrder()
        {
            try
            {
                System.Console.WriteLine("\n--- Update Order ---");
                System.Console.Write("Enter Order ID to Update: ");
                
                if (!int.TryParse(System.Console.ReadLine(), out int id))
                {
                    System.Console.WriteLine("Invalid Order ID format.");
                    return;
                }

                var order = _orderService.GetById(id);
                if (order == null)
                {
                    System.Console.WriteLine("Order not found.");
                    return;
                }

                System.Console.WriteLine($"Current Order: {order}");
                System.Console.WriteLine("\nEnter new details:");
                
                System.Console.Write("Enter New Product ID: ");
                if (int.TryParse(System.Console.ReadLine(), out int productId))
                    order.productId = productId;

                System.Console.Write("Enter New Quantity: ");
                if (int.TryParse(System.Console.ReadLine(), out int quantity))
                    order.quantity = quantity;

                System.Console.Write("Enter New Total Price: ");
                if (double.TryParse(System.Console.ReadLine(), out double totalPrice))
                    order.totalPrice = totalPrice;

                order.orderDate = DateTime.Now; // Update to current time

                _orderService.Update(order);
                System.Console.WriteLine("Order updated successfully.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error updating order: {ex.Message}");
            }
        }

        private void DeleteOrder()
        {
            try
            {
                System.Console.WriteLine("\n--- Delete Order ---");
                System.Console.Write("Enter Order ID to Delete: ");
                
                if (!int.TryParse(System.Console.ReadLine(), out int id))
                {
                    System.Console.WriteLine("Invalid Order ID format.");
                    return;
                }

                var order = _orderService.GetById(id);
                if (order == null)
                {
                    System.Console.WriteLine("Order not found.");
                    return;
                }

                System.Console.WriteLine($"Order to delete: {order}");
                System.Console.Write("Are you sure you want to delete this order? (y/n): ");
                
                var confirmation = System.Console.ReadLine()?.ToLower();
                if (confirmation == "y" || confirmation == "yes")
                {
                    _orderService.Delete(id);
                    System.Console.WriteLine("Order deleted successfully.");
                }
                else
                {
                    System.Console.WriteLine("Order deletion cancelled.");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error deleting order: {ex.Message}");
            }
        }

        private void ViewAllOrders()
        {
            try
            {
                System.Console.WriteLine("\n--- All Orders ---");
                var orders = _orderService.GetAll();
                
                if (orders.Count == 0)
                {
                    System.Console.WriteLine("No orders available.");
                    return;
                }

                System.Console.WriteLine($"{"ID",-5} {"Product ID",-12} {"Quantity",-10} {"Total Price",-15} {"Order Date",-20}");
                System.Console.WriteLine(new string('-', 70));

                foreach (var order in orders.OrderBy(o => o.id))
                {
                    System.Console.WriteLine($"{order.id,-5} {order.productId,-12} {order.quantity,-10} ${order.totalPrice,-14:F2} {order.orderDate,-20:yyyy-MM-dd HH:mm}");
                }
                
                System.Console.WriteLine(new string('-', 70));
                System.Console.WriteLine($"Total Orders: {orders.Count}");
                System.Console.WriteLine($"Total Value: ${orders.Sum(o => o.totalPrice):F2}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error retrieving orders: {ex.Message}");
            }
        }

        private void ViewOrderById()
        {
            try
            {
                System.Console.WriteLine("\n--- View Order by ID ---");
                System.Console.Write("Enter Order ID: ");
                
                if (!int.TryParse(System.Console.ReadLine(), out int id))
                {
                    System.Console.WriteLine("Invalid Order ID format.");
                    return;
                }

                var order = _orderService.GetById(id);
                if (order == null)
                {
                    System.Console.WriteLine("Order not found.");
                    return;
                }

                System.Console.WriteLine("\n--- Order Details ---");
                System.Console.WriteLine($"Order ID: {order.id}");
                System.Console.WriteLine($"Product ID: {order.productId}");
                System.Console.WriteLine($"Quantity: {order.quantity}");
                System.Console.WriteLine($"Total Price: ${order.totalPrice:F2}");
                System.Console.WriteLine($"Order Date: {order.orderDate:yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error retrieving order: {ex.Message}");
            }
        }
    }
}