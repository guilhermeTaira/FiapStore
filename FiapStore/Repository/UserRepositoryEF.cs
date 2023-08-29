using FiapStore.Entities;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class UserRepositoryEF : EFRepository<User>, IUserRepository
    {
        public UserRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }

        public User GetWithOrders(int id)
        {
            return _context.User
                    .Include(u => u.Orders)
                    .Where(x => x.Id == id)
                    .ToList()
                    .Select(user =>
                    {
                        user.Orders = user.Orders.Select(order => new Order(order)).ToList();
                        return user;
                    })
                    .FirstOrDefault();
        }

        //password validation this way for didactic purposes
        public User GetByUsernameAndPassword(string userName, string password)
        {
            return _context.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
