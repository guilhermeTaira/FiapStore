using FiapStore.Entities;

namespace FiapStore.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetWithOrders(int id);
    }
}
