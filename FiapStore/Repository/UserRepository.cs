using Dapper;
using FiapStore.Entities;
using FiapStore.Repository;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace FiapStore.Interface
{
    public class UserRepository : DapperRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Add(User entity)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO [User]([Name]) VALUES(@Name)";
            dbconnection.Execute(query, entity);
        }

        public override void Delete(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM [User] WHERE Id = @Id";
            dbconnection.Execute(query, new { Id = id });
        }

        public override IList<User> GetAll()
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [User]";
            return dbconnection.Query<User>(query).ToList();
        }

        public override User GetById(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [User] Where Id = @Id";
            return dbconnection.Query<User>(query, new { Id = id }).FirstOrDefault();
        }

        public override void Update(User entity)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "UPDATE [User] SET [Name] = @Name WHERE Id = @Id";
            dbconnection.Query(query, entity);
        }

        public User GetWithOrders(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = @"SELECT
                            U.Id,
                            U.Name,
                            O.Id,
                            O.ProductName,
                            O.UserId
                        FROM
                            [User] U
                            LEFT JOIN [Order] O ON U.Id = O.UserId
                        WHERE 
                            U.Id = @Id";

            var result = new Dictionary<int, User>();
            var param = new { Id = id };

            dbconnection.Query<User, Order, User>(query,
                (user, order) =>
                {
                    if (!result.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.Orders = new List<Order>();
                        result.Add(user.Id, existingUser);
                    }

                    if (order != null)
                        existingUser.Orders.Add(order);

                    return existingUser;
                }, param, splitOn: "Id");

            return result.Values.FirstOrDefault();
        }
    }
}
