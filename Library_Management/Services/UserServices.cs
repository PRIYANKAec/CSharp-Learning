namespace Library
{
    public class UserServices
    {
        private readonly IUserRepo<User, int> _userRepo;
        public UserServices(IUserRepo<User, int> userRepo)
        {
            _userRepo = userRepo;
        }

        public User AddUser(User user)
        {
            try
            {
                if (user == null || string.IsNullOrWhiteSpace(user.UserName))
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null or Empty");
                }
                if (user.password == "Unknown" || user.password == null)
                {
                    throw new ArgumentException("Password cannot be 'Unknown' or null");
                }
                return _userRepo.Add(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw;
            }
        }
        public User GetUserById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
                }
                return _userRepo.GetUserById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                throw;
            }
        }
        public User UpdateUser(User user)
        {
            try
            {
                if (user == null || user.UserId <= 0)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null and must have a valid ID");
                }
                return _userRepo.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }
        public void DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
                }
                _userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                throw;
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepo.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all users: {ex.Message}");
                throw;
            }
        }

        public List<User> GetUsersByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));
                }
                return _userRepo.GetByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users by name: {ex.Message}");
                throw;
            }
        }    
    }
}