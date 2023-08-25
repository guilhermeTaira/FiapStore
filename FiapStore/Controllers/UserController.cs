using FiapStore.DTO;
using FiapStore.Entities;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("get-user-with-orders-by-id/{id}")]
        public IActionResult GetUserWithOrdersById(int id)
        {
            return Ok(_userRepository.GetWithOrders(id));
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDTO userDTO)
        {
            _userRepository.Add(new User(userDTO));
            return Ok("User added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO userDTO)
        {
            _userRepository.Update(new User(userDTO));
            return Ok("User updated successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("User deleted successfully!");
        }
    }
}
