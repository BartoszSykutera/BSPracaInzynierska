using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class InGamePlayerInfo : GameAnswers
    {
        public User Player { get; set; }
        public bool isAnswered { get; set; } = false;
    }
}