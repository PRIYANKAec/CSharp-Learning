namespace Library
{
    public class UserLibrary
    {
        private readonly UserServices _userServices;

        public UserLibrary(UserServices userServices)
        {
            _userServices = userServices;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("----USER MANAGEMENT-----");
                Console.WriteLine("1. Add User\t2. Update User\t3. Delete User\t4. View All Users\t5. Search by Name\t6. SearchById\t7. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        UpdateUser();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        ViewAllUsers();
                        break;
                    case "5":
                        SearchByName();
                        break;
                    case "6":
                        SearchById();
                        break;
                    case "7":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddUser()
        {
            var user = new User();
            user.GetUSerFromInput();
            try
            {
                _userServices.AddUser(user);
                Console.WriteLine("User added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }

        private void UpdateUser()
        {
            Console.WriteLine("Enter User ID to update:");
            int userId = Convert.ToInt32(Console.ReadLine());
            var user = _userServices.GetUserById(userId);
            if (user != null)
            {
                user.GetUSerFromInput();
                try
                {
                    _userServices.UpdateUser(user);
                    Console.WriteLine("User updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating user: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void DeleteUser()
        {
            Console.WriteLine("Enter User ID to delete:");
            int userId = Convert.ToInt32(Console.ReadLine());
            try
            {
                _userServices.DeleteUser(userId);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
            }
        }

        private void ViewAllUsers()
        {
            try
            {
                var users = _userServices.GetAllUsers();
                if (users.Count > 0)
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Enter User Name to search:");
            string userName = Console.ReadLine();
            try
            {
                var users = _userServices.GetUsersByName(userName);
                if (users.Count > 0)
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                }
                else
                {
                    Console.WriteLine("No users found with that name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching users: {ex.Message}");
            }
        }

        private void SearchById()
        {
            Console.WriteLine("Enter User ID to search:");
            int userId = Convert.ToInt32(Console.ReadLine());
            try
            {
                var user = _userServices.GetUserById(userId);
                if (user != null)
                {
                    Console.WriteLine(user);
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching user: {ex.Message}");
            }
        }
    }
}