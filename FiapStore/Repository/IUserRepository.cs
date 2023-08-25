using FiapStore.Entity;

namespace FiapStore.Interface
{
    public class UserRepository : IUserRepository
    {
        private IList<User> _users = new List<User>();

        public IList<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void EditUser(User user)
        {
            var editedUser = GetUserById(user.Id);

            if(editedUser != null)
                editedUser.Name = user.Name;
        }

        public void DeleteUser(int id)
        {
            _users.Remove(GetUserById(id));
        } 
    }
}
