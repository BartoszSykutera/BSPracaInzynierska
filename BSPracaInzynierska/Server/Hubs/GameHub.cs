using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BSPracaInzynierska.Server.Hubs
{
    public class GameHub : Hub
    {
        private readonly DataContext _context;

        public GameHub(DataContext context)
        {
            _context = context;
        }
        public static HashSet<UserConnectionInfo> userConnectionInfos = new HashSet<UserConnectionInfo>();

        public async Task SendMessage(string cos)
        {
            //string ToUserId = userConnectionInfos.Where(u => u.UserId == cos).FirstOrDefault()?.ConnectionId;
            string ToUserId = "qwerr";
            //string FromUserId = userConnectionInfos.Where(u => u.UserId == qwer).FirstOrDefault()?.ConnectionId;
            var users = new string[] { ToUserId };
            var dfg = Context.ConnectionId;
            var fgdf = Context.User.Identity.Name;
            await Clients.Client(ToUserId).SendAsync("SetHost", true);
        }

        public async Task SendTimeStamp(InGamePlayerInfo user, string gameId)
        {
            //List<UserConnectionInfo> users = userConnectionInfos.Where(u => u.GameId == gameId).ToList();
            foreach (var connection in userConnectionInfos)
            {
                if (connection.GameId == gameId)
                {
                    await Clients.Client(connection.ConnectionId).SendAsync("UpdateLeaderboard", user);
                }
            }
        }

        public async Task Join(string userId, string gameId)
        {
            User newPlayer = _context.Uzytkownicy.Where(u => u.Id == new Guid(userId)).FirstOrDefault();
            var game = userConnectionInfos.Where(g => g.GameId == gameId).FirstOrDefault();
            UserConnectionInfo newConnection;
            if (game == null)
            {
                newConnection = new UserConnectionInfo { UserId = newPlayer, ConnectionId = Context.ConnectionId, isReady = false, GameId = gameId, isHost = true };
            }
            else
            {
                newConnection = new UserConnectionInfo { UserId = newPlayer, ConnectionId = Context.ConnectionId, isReady = false, GameId = gameId, isHost = false };
            }

            userConnectionInfos.Add(newConnection);
            List<UserConnectionInfo> users = userConnectionInfos.Where(u => u.GameId == gameId).ToList();
            foreach (var connection in userConnectionInfos)
            {
                if (connection.GameId == gameId)
                {
                    await Clients.Client(connection.ConnectionId).SendAsync("UpdatePlayerList", users);
                }
            }
        }

        public async Task NextRound(List<User> players)
        {
            foreach (var player in players)
            {
                string userConn = userConnectionInfos.Where(u => u.UserId.Id == player.Id).FirstOrDefault()?.ConnectionId;
                await Clients.Client(userConn).SendAsync("StartNextRound");
            }

        }

        public async Task StartGame(List<User> players)
        {
            foreach (var player in players)
            {
                string userConn = userConnectionInfos.Where(u => u.UserId.Id == player.Id).FirstOrDefault()?.ConnectionId;
                await Clients.Client(userConn).SendAsync("StartNewGame");
            }

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var gameId = userConnectionInfos.Where(u => u.ConnectionId == Context.ConnectionId).FirstOrDefault().GameId;
            var userConn = userConnectionInfos.Where(u => u.ConnectionId == Context.ConnectionId).FirstOrDefault();
            var game = await _context.Game.Include(g => g.Players).Include(g => g.Playlist).ThenInclude(p => p.Songs).Where(g => g.Id == new Guid(gameId)).FirstOrDefaultAsync();
            userConnectionInfos.RemoveWhere(u => u.ConnectionId == Context.ConnectionId);
            List<UserConnectionInfo> users = userConnectionInfos.Where(u => u.GameId == gameId).ToList();
            if (userConn.isHost == true)
            {
                game.Players.ToList().ForEach(p =>
                {
                    p.currentGameId = null;
                });
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
                foreach (var connection in userConnectionInfos)
                {
                    if (connection.GameId == gameId)
                    {
                        await Clients.Client(connection.ConnectionId).SendAsync("DisconnectFromGame");
                    }
                }
            }
            else if (userConn.isHost != true)
            {
                if (game != null)
                {
                    game.Players.ToList().ForEach(p =>
                    {
                        if (p.Id == userConn.UserId.Id)
                        {
                            p.currentGameId = null;
                            game.Players.Remove(p);
                            return;
                        }
                    });
                    await _context.SaveChangesAsync();
                    foreach (var connection in userConnectionInfos)
                    {
                        if (connection.GameId == gameId)
                        {
                            await Clients.Client(connection.ConnectionId).SendAsync("UpdatePlayerList", users);
                        }
                    }
                }

            }

        }
    }
}
