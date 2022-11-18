using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BSPracaInzynierska.Shared;
using System.Text;
using BSPracaInzynierska.Server.DB;
using Microsoft.EntityFrameworkCore;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //public static User user = new User();
        //public List<User> users = new List<User>();
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = User?.Identity?.Name;
            var userName2 = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { userName, userName2, role });
        }

        [HttpPost("getcurrentuser")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            User currentUser = new User();

            if (User.Identity.IsAuthenticated)
            {
                currentUser.Username = User.FindFirstValue(ClaimTypes.Name);
            }

            return Ok(currentUser);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserLogs userLogs)
        {
            CreatePasswordHash(userLogs.Password, out byte[] hash, out byte[] salt);
            var user = new User { Username = userLogs.Username, Email = userLogs.Username, PasswordHash = hash, PasswordSalt = salt, Id = 1, Role = "Admin" };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationToken>> Login(UserLogs userLogs)
        {
            string token = string.Empty;
            //var user = context.Users.Where(u => u.Username == userLogs.Username).FirstOrDefault();

            //if (user == null)
            //{
            //return BadRequest("User not found");
            //}

            //if (!VerifyPasswordHash(userLogs.Password, user.PasswordHash, user.PasswordSalt))
            //{
            //return BadRequest("Wrong password");
            //}

            var user = new User { Username = "QQQ", Email = "qq", Id = 1, Role = "Admin" };

            token = CreateToken(user);

            return Ok(new AuthenticationToken() { Token = token });
        }
        
        [HttpPost("getuserbyjwt")]
        public async Task<ActionResult<User>> GetUserByJWT([FromBody]string jwt)
        {
            try
            {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                var principle = tokenHandler.ValidateToken(jwt, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;

                if(jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase))
                {
                    var user = new User { Username = "QQQ", Email = "qq", Id = 1, Role = "Admin" };
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    //return await GetUserById(Convert.ToInt64(userId));
                    return user;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return null;
        }

        protected async Task<User> GetUserById(long userId)
        {
            return await context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
        
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(hash);
            }
        }
    }
}
