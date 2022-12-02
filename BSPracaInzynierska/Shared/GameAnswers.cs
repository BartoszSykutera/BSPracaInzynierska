using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class GameAnswers
    {
        public Guid Id = Guid.NewGuid();
        public double timeStamp {  get; set; }
        public bool isCorrect { get; set; }
        public double Points { get; set; } = 0;
        public string correctAnswer { get; set; }
    }
}
