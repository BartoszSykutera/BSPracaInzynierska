using BSPracaInzynierska.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BSPracaInzynierska.Client.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(HttpClient httpClient, Blazored.LocalStorage.ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorageService = localStorage;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User currentUser = await GetUserByJWT();

            if (currentUser != null && currentUser.Username != string.Empty)
            {
                var claimUsername = new Claim(ClaimTypes.Name, currentUser.Username);
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.Id));
                var claimRole = new Claim(ClaimTypes.Role, currentUser.Role);
                var claimsIdentity = new ClaimsIdentity(new[] { claimUsername, claimNameIdentifier, claimRole }, "serverAuth");
                var claimPrinciple = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimPrinciple);
            }
            else
            {
                await _localStorageService.RemoveItemAsync("jwt_token");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
                
        }

        public async Task<User> GetUserByJWT()
        {
            var jwt = await _localStorageService.GetItemAsStringAsync("jwt_token");
            if (jwt == null) return null;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Auth/getuserbyjwt");
            requestMessage.Content = new StringContent(jwt);

            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var returnedUser = await response.Content.ReadFromJsonAsync<User>();

            if (returnedUser.Username != string.Empty)
                return await Task.FromResult(returnedUser);
            else return null;

        }
    }
}
