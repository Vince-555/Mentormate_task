using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentormate
{
    public class Game
    {
        public Engine GameEngine { get; set; }
        public int NumberOfTurns { get; set; }

        public int GameCellX { get; set; }
        public int GameCellY { get; set; }
        public int TimesGreen { get; set; }
    }
}
