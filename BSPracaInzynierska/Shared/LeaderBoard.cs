using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class LeaderBoard
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public virtual User? Player { get; set; }
        public Guid? PlaylistId { get; set; }
        [JsonIgnore]
        public virtual MusicPlaylist? Playlist { get; set; }
        public double? playerTime { get; set; }
        public double Points { get; set; }
        public string gameType { get; set; }
    }
}
