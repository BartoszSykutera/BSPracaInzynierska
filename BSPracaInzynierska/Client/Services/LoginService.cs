using BSPracaInzynierska.Shared;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services
{
    public class LoginService : ILoginService
    {

        private readonly HttpClient http;
        public LoginService(HttpClient http)
        {
            this.http = http;
        }
        public string errorMess { get; set; } = string.Empty;
        public async Task<AuthenticationToken> Login(string username, string password)
        {
            UserLogs userLogs = new UserLogs { Password = password, Username = username };
            var result = await http.PostAsJsonAsync<UserLogs>("api/Auth/login", userLogs);

            return await result.Content.ReadFromJsonAsync<AuthenticationToken>();
        }

        public async Task Register(string username, string password)
        {
            UserLogs userLogs = new UserLogs { Password = password, Username = username };
            var result = await http.PostAsJsonAsync<UserLogs>("api/Auth/register", userLogs);
            if(result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                errorMess = await result.Content.ReadAsStringAsync();
            }
        }
    }
}
