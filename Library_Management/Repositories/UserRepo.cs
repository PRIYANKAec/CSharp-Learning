namespace Library
{
    public class UserRepo : IUserRepo<User, int>
    {
        private List<User> _user = new List<User>();

        public User Add(User user)
        {
            _user.Add(user);
            return user;
        }

        public User GetUserById(int id)
        {
            return _user.FirstOrDefault(u => u.UserId == id);
        }
        
        public List<User> GetAll()
        {
            return _user;
        }

        public List<User> GetByName(string name)
        {
            return _user.Where(u => u.UserName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public User Update(User user)
        {
            var existingUser = GetUserById(user.UserId);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.password = user.password;
                existingUser.BorrowedBooks = user.BorrowedBooks;
                existingUser.BorrowedBookCount = user.BorrowedBookCount;
            }
            return existingUser;
        }
        
        public void Delete(int id)
        {
            if (GetUserById(id) != null)
            {
                _user.Remove(GetUserById(id));
            }
        }
    }
}