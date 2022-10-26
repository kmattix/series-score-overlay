using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesScoreOverlay
{
    public class Scoreboard
    {
        public string homeName, awayName;
        public int homeScore, awayScore;
        public bool visable;
        
        public Scoreboard(string _homeName, string _awayName)
        {
            homeName = _homeName;
            awayName = _awayName;
            homeScore = 0;
            awayScore = 0;
            visable = false;
        }
    }
}
