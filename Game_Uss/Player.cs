using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Player
    {
        public string Name { get; private set; }
        public int BestScore { get; set; }

        public Player(string name, int BestScore)
        {
            this.Name = name;
            this.BestScore = BestScore;
        }

    }
}
