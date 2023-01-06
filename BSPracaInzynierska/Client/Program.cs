using Blazored.LocalStorage;
using Blazored.Modal;
using BSPracaInzynierska.Client;
using BSPracaInzynierska.Client.Services;
using BSPracaInzynierska.Client.Services.BlindGuessGameService;
using BSPracaInzynierska.Client.Services.GameCreatorService;
using BSPracaInzynierska.Client.Services.GameOneServices;
using BSPracaInzynierska.Client.Services.Handlers;
using BSPracaInzynierska.Client.Services.MultiplayerService;
using BSPracaInzynierska.Client.Services.PlaylistService;
using BSPracaInzynierska.Client.Services.ProfileServices;
using BSPracaInzynierska.Client.Services.UserServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//.AddHttpMessageHandler<MyAuthorizationHandler>()
/*
HttpMessageHandler httpMessageHandler = new MyAuthorizationHandler()
{
    InnerHandler = new HttpClientHandler();
};
builder.Services.AddScoped<MyAuthorizationHandler>(sc => httpMessageHandler);
var httpClient = new HttpClient(httpMessageHandler)
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
builder.Services.AddScoped(sp => httpClient);
*/
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOptions();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<IUserService,  UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IMainPageService, MainPageService>();
builder.Services.AddScoped<IGameOneService, GameOneService>();
builder.Services.AddScoped<IGameCreatorService, GameCreatorService>();
builder.Services.AddScoped<IBlindGuessService, BlindGuessService>();
builder.Services.AddScoped<IMultiplayerService, MultiplayerService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

await builder.Build().RunAsync();
