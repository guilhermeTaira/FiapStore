using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUserRepository
    {
        IList<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int id);
    }
}
