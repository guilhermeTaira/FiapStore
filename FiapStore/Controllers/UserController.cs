using FiapStore.DTO;
using FiapStore.Entities;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Returns a user with orders by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        /// Send Id 1 to the Request
        /// </remarks>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissions.Employee)]
        [HttpGet("get-user-with-orders-by-id/{id}")]
        public IActionResult GetUserWithOrdersById(int id)
        {
            try
            {
                return Ok(_userRepository.GetWithOrders(id));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Exception on GetUserWithOrdersById(): {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception on GetAllUsers(): {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns a user by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        /// Send Id 1 to the Request
        /// </remarks>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissions.Employee)]
        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userRepository.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception on GetUserById(): {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissions.Employee}, {Permissions.Admin}")]
        [HttpPost]
        public IActionResult AddUser(AddUserDTO userDTO)
        {
            try
            {
                _userRepository.Add(new User(userDTO));

                var message = $"User added successfully! | Name: {userDTO.Name}";
                _logger.LogInformation(message);

                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception on AddUser(): {ex.Message}");
                return BadRequest();
            } 
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO userDTO)
        {
            try
            {
                _userRepository.Update(new User(userDTO));

                var message = $"User updated successfully! | Name: {userDTO.Name}";
                _logger.LogInformation(message);

                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception on UpdateUser(): {ex.Message}");
                return BadRequest();
            }  
        }

        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);

                var message = $"User deleted successfully! | Id: {id}";
                _logger.LogInformation(message);

                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception on DeleteUser(): {ex.Message}");
                return BadRequest();
            } 
        }
    }
}
