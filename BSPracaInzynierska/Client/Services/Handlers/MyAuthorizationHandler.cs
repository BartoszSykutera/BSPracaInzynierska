using Blazored.LocalStorage;

namespace BSPracaInzynierska.Client.Services.Handlers
{
    public class MyAuthorizationHandler : DelegatingHandler
    {
        public ILocalStorageService localStorage;

        public MyAuthorizationHandler(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwt = await localStorage.GetItemAsync<string>("jwt_token");

            if (jwt != null)
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
