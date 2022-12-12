using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class MusicPlaylist
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PlaylistName { get; set; } = string.Empty;
        public int NumberOfTracks { get; set; }
        public string Description { get; set; } = string.Empty;
        public long favourites { get; set; } = 0;
        public int blindGuessTime { get; set; } = 30;
        public int blindGuessSongs { get; set; }
        public int lightningRoundTime { get; set; } = 5;
        public int lightningRoundSongs { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? Creator { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<LeaderBoard>? LeaderBoards { get; set; }
        [JsonIgnore]
        public virtual ICollection<MultiGame>? CurrentGames { get; set; }
        [JsonIgnore]
        public virtual ICollection<User>? UsersFavourites { get; set; }

    }
}
