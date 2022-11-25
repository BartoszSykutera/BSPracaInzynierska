using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class GameTypeOne
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int NumberOfTracks { get; set; }
        public bool type = true;
        public int? points {  get; set; }
        public int? gameTime { get; set; }
        public Guid? UserId { get; set; }
        [JsonIgnore]
        public virtual User? Player { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
