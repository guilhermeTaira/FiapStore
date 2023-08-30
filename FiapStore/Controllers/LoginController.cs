using FiapStore.DTO;
using FiapStore.Interface;
using FiapStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticate with UserName and Password
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO loginDTO)
        {
            var user = _userRepository.GetByUsernameAndPassword(loginDTO.UserName, loginDTO.Password);

            if(user == null)
                return BadRequest("UserName or Password invalid!");

            var token = _tokenService.GenerateToken(user);

            user.Password = null;
            return Ok(new
            {
                User = user,
                Token = token,
            });
        }
    }
}
