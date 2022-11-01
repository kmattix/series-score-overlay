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

    public enum Series
    {
        Bo1 = 1,
        Bo3 = 2,
        Bo5 = 3,
        Bo7 = 4,
        Bo9 = 5
    }

    public enum Game
    {
        RocketLeague,
        LeagueOfLegends,
        //Valorant,
        //SmashUltimate,
        //NBA2k,
        //FIFA
    }

    public class Scoreboard
    {
        private string homeName, awayName;
        public Series series { get; set; }
        public int homeScore { get; private set; }
        public int awayScore { get; private set; }
        public bool isVisable { get; private set; }
        private LeagueOfLegendsOverlay view;

        public Scoreboard(string _homeName, string _awayName)
        {
            homeName = _homeName;
            awayName = _awayName;
            series = Series.Bo1;
            homeScore = 0;
            awayScore = 0;
            isVisable = false;
            view = new LeagueOfLegendsOverlay();
        }

        public void apply()
        {
            if (!isVisable)
            {
                view = new LeagueOfLegendsOverlay();
                view.Show();
                isVisable = true;
            }
            view.homeTeamText.Text = homeName;
            view.homeTeamScoreText.Text = homeScore.ToString();
            view.awayTeamText.Text = awayName;
            view.awayTeamScoreText.Text = awayScore.ToString();
            view.seriesTypeText.Text = series.ToString();
            view.gameNumberText.Text = (homeScore >= (int) series) || (awayScore >= (int) series)? 
                "Final" : $"Game {homeScore + awayScore + 1}";
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

            int MAX_SCORE = (int) series;

            if ((team == Team.Home) && (homeScore + 1 <= MAX_SCORE)) homeScore++;
            if ((team == Team.Away) && (awayScore + 1 <= MAX_SCORE)) awayScore++;
        }

        public void removeScore(Team team)
        {
            if (!isVisable) return;

            if (team == Team.Home && homeScore > 0) homeScore--;
            else if (awayScore > 0) awayScore--;
        }
    }
}
