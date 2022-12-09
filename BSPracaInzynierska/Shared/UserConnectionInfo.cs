using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class UserConnectionInfo
    {
        public User UserId { get; set; }
        public string ConnectionId { get; set; }
        public bool isReady { get; set; }
        public string GameId { get; set; }
        public bool isHost { get; set; }
    }
}
