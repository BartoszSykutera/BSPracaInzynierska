using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class MultiGame
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int NumberOfTracks { get; set; }
        public double gameTime { get; set; }
        public MusicPlaylist Playlist { get; set; }
        public Guid UserHost {  get; set; }
        public List<User>? Players { get; set; }
        public string? GameCode { get; set; }
    }
}
