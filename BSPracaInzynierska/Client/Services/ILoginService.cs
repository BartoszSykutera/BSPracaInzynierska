using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services
{
    public interface ILoginService
    {
        public string errorMess {  get; set; }
        public Task<AuthenticationToken> Login(string username, string password);
        public Task Register(string username, string password);
    }
}
