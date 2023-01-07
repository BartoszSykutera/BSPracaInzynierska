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
using System.Net.Http;
using Google.Apis.YouTube.v3;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [HttpGet("profile/{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await context.Uzytkownicy.Include(u => u.FavouritePlaylists).ThenInclude(p => p.Songs).Include(u => u.FavouritePlaylists).ThenInclude(p => p.Creator).Where(u => u.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserLogs userLogs)
        {
            CreatePasswordHash(userLogs.Password, out byte[] hash, out byte[] salt);
            var user = new User { Username = userLogs.Username, Email = userLogs.Username, PasswordHash = hash, PasswordSalt = salt };
            context.Uzytkownicy.Add(user);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationToken>> Login(UserLogs userLogs)
        {
            List<User> users = await context.Uzytkownicy.ToListAsync();
            string token = string.Empty;
            var user = context.Uzytkownicy.Where(u => u.Username == userLogs.Username).FirstOrDefault();

            if(user == null || !VerifyPasswordHash(userLogs.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Ok(new AuthenticationToken() { Token = token });
            }

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
                    //var user = new User { Username = "QQQ", Email = "qq", Role = "Admin" };
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    return await GetUserById(new Guid(userId));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new User();
            }
            return new User();
        }

        protected async Task<User> GetUserById(Guid userId)
        {
            User user = null;
            user = await context.Uzytkownicy.Where(u => u.Id == userId).FirstOrDefaultAsync();
            if(user == null)
            {
                return new User();
            }
            return user;
        }
        
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimIdentity = new ClaimsIdentity(claims);

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
