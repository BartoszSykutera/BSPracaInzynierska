using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class Song
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Picture {  get; set; } = string.Empty;
        public Guid? PlaylistId { get; set; }
        public string YTVideoTitle { get; set; } = string.Empty;
        public string YTVidoeId { get; set; } = string.Empty;
        public string YTChanelName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual MusicPlaylist? Playlist { get; set; }
    }
}
