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
        public async Task<string> Login(string username, string password)
        {
            UserLogs userLogs = new UserLogs { Password = password, Username = username };
            var result = await http.PostAsJsonAsync<UserLogs>("api/Auth/login", userLogs);

            return await result.Content.ReadFromJsonAsync<string>();
        }

        public async Task Register(string username, string password)
        {
            UserLogs userLogs = new UserLogs { Password = password, Username = username };
            var result = await http.PostAsJsonAsync<UserLogs>("api/Auth/register", userLogs);
        }
    }
}
