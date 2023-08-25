using FiapStore.DTO;

namespace FiapStore.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

        public User()
        {
        }

        public User(AddUserDTO addUserDTO)
        {
            Name = addUserDTO.Name;
        }

        public User(UpdateUserDTO updateUserDTO)
        {
            Name = updateUserDTO.Name;
            Id = updateUserDTO.Id;
        }
    }
}
