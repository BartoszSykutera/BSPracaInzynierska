using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BSPracaInzynierska.Server.Hubs
{
    public class GameHub : Hub
    {
        //private List<UserConnectionInfo> userConnectionInfos = new List<UserConnectionInfo>();
        public static HashSet<UserConnectionInfo> userConnectionInfos = new HashSet<UserConnectionInfo>();

        public async Task SendMessage(string cos, string qwer)
        {
            //string ToUserID = _context.Uzytkownicy.Where(u => u.Username == cos).FirstOrDefault().Id.ToString();
            //string FromUserID = _context.Uzytkownicy.Where(u => u.Username == cus).FirstOrDefault().Id.ToString();
            //var users = new string[] { cos, cus };
            string ToUserId = userConnectionInfos.Where(u => u.UserId == cos).FirstOrDefault()?.ConnectionId;
            string FromUserId = userConnectionInfos.Where(u => u.UserId == qwer).FirstOrDefault()?.ConnectionId;
            var users = new string[] { ToUserId, FromUserId };
            var dfg = Context.ConnectionId;
            var fgdf = Context.User.Identity.Name;
            await Clients.Clients(users).SendAsync("Receive", cos);
        }

        public async Task Join(string userId)
        {
            UserConnectionInfo newConnection = new UserConnectionInfo { UserId = userId, ConnectionId = Context.ConnectionId };
            userConnectionInfos.Add(newConnection);
        }
    }
}
