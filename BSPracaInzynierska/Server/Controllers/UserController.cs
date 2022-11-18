using BSPracaInzynierska.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>();
        
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if(user == null)
            {
                return NotFound("There is no such user");
            }

            return Ok(user);
        }
    }
}
