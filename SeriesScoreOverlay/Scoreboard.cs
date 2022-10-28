using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesScoreOverlay
{
    public enum Team
    {
        Home,
        Away
    }

    public class Scoreboard
    {
        private string homeName, awayName;
        public int homeScore { get; private set; }
        public int awayScore { get; private set; }
        public bool isVisable { get; private set; }
        private OverlayWindow view;
        
        public Scoreboard(string _homeName, string _awayName)
        {
            homeName = _homeName;
            awayName = _awayName;
            homeScore = 0;
            awayScore = 0;
            isVisable = false;
            view = new OverlayWindow();
        }

        public void apply()
        {
            if (!isVisable)
            {
                view = new OverlayWindow();
                view.Show();
                isVisable = true;
            }
            view.homeTeamText.Text = homeName;
            view.homeTeamScoreText.Text = homeScore.ToString();
            view.awayTeamText.Text = awayName;
            view.awayTeamScoreText.Text = awayScore.ToString();
        }

        public void clear()
        {
            if (isVisable)
            {
                view.Close();
                isVisable = false;
            }

            homeScore = 0;
            awayScore = 0;
        }

        public void changeName(Team team, string name)
        {
            name = name.ToUpper();

            if(team == Team.Home) homeName = name;
            else awayName = name;
        }

        public void addScore(Team team)
        {
            if (!isVisable) return;

            if (team == Team.Home) homeScore++;
            else awayScore++;
        }

        public void removeScore(Team team)
        {
            if (!isVisable) return;

            if (team == Team.Home && homeScore > 0) homeScore--;
            else if (awayScore > 0) awayScore--;
        }
    }
}
