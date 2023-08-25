using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers() 
        {
            return Ok("Usuários obtidos com sucesso!");
        }

        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById()
        {
            return Ok("Usuário obtido com sucesso!");
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            return Ok("Usuário adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult EditUser()
        {
            return Ok("Usuário alterado com sucesso!");
        }

        [HttpDelete]
        public IActionResult DeleteUser()
        {
            return Ok("Usuário deletado com sucesso!");
        }
    }
}
