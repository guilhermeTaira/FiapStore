using FiapStore.DTO;
using FiapStore.Enums;

namespace FiapStore.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Permisisons Permission { get; set; }

        public ICollection<Order> Orders { get; set; }

        public User()
        {
        }

        public User(AddUserDTO addUserDTO)
        {
            Name = addUserDTO.Name;
            UserName = addUserDTO.UserName;
            Password = addUserDTO.Password;
            Permission = addUserDTO.Permission;
        }

        public User(UpdateUserDTO updateUserDTO)
        {
            Name = updateUserDTO.Name;
            Id = updateUserDTO.Id;
        }
    }
}
