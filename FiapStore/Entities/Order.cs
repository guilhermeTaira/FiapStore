namespace FiapStore.Entities
{
    public class Order : Entity
    {
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Order()
        {
        }

        public Order(Order order)
        {
            ProductName = order.ProductName;
            UserId = order.UserId;
        }
    }
}
