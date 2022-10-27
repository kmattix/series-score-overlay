using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesScoreOverlay
{
    public class Scoreboard
    {
        private string homeName, awayName;
        private int homeScore, awayScore;
        private bool visable;
        private OverlayWindow view;
        
        public Scoreboard(string _homeName, string _awayName)
        {
            homeName = _homeName;
            awayName = _awayName;
            homeScore = 0;
            awayScore = 0;
            visable = false;
            view = new OverlayWindow();
        }

        public void apply()
        {
            if (!visable)
            {
                view = new OverlayWindow();
                view.Show();
                visable = true;
            }
            view.homeTeamText.Text = homeName;
            view.homeTeamScoreText.Text = homeScore.ToString();
            view.awayTeamText.Text = awayName;
            view.awayTeamScoreText.Text = awayScore.ToString();
        }

        public void clear()
        {
            if (visable)
            {
                view.Close();
                visable = false;
            }
            homeName = "";
            awayName = "";
            homeScore = 0;
            awayScore = 0;
        }

        public void changeHomeName(string name)
        {
            homeName = name.ToUpper();
        }

        public void changeAwayName(string name)
        {
            awayName = name.ToUpper();
        }

        public void addHomeScore()
        {
            if (visable)
                homeScore++;
        }

        public void removeHomeScore()
        {
            if (visable && homeScore > 0)
                homeScore--;
        }

        public void addAwayScore()
        {
            if (visable)
                awayScore++;
        }

        public void removeAwayScore()
        {
            if (visable && awayScore > 0)
                awayScore--;
        }
    }
}
