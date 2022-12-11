using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "User";
        public Guid? currentGameId { get; set; }
        [JsonIgnore]
        public virtual ICollection<MusicPlaylist>? MusicPlaylists { get; set; }
        [JsonIgnore]
        public virtual MultiGame? CurrentGame { get; set; }
    }
}
