using Blazored.LocalStorage;
using BSPracaInzynierska.Client;
using BSPracaInzynierska.Client.Services;
using BSPracaInzynierska.Client.Services.UserServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//.AddHttpMessageHandler<MyAuthorizationHandler>()
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOptions();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IUserService,  UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();

await builder.Build().RunAsync();
