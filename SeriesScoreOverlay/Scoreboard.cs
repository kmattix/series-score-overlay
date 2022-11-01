using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public Game game { get; set; }
        public int homeScore { get; private set; }
        public int awayScore { get; private set; }
        public bool isVisable { get; private set; }
        private Window view;

        public Scoreboard(string _homeName, string _awayName)
        {
            homeName = _homeName;
            awayName = _awayName;
            series = Series.Bo1;
            game = Game.RocketLeague;
            homeScore = 0;
            awayScore = 0;
            isVisable = false;
            view = new Window();
        }

        public void apply()
        {
            switch (game)
            {
                case Game.RocketLeague:
                {
                    if (!isVisable) view = new RocketLeagueOverlay();
                    ((RocketLeagueOverlay) view).homeTeamText.Text = homeName;
                    ((RocketLeagueOverlay) view).homeTeamScoreText.Text = homeScore.ToString();
                    ((RocketLeagueOverlay) view).awayTeamText.Text = awayName;
                    ((RocketLeagueOverlay) view).awayTeamScoreText.Text = awayScore.ToString();
                    ((RocketLeagueOverlay) view).seriesTypeText.Text = series.ToString();
                    ((RocketLeagueOverlay) view).gameNumberText.Text = gameNumber();
                    break;
                }
                case Game.LeagueOfLegends:
                {
                    if (!isVisable) view = new LeagueOfLegendsOverlay();
                    ((LeagueOfLegendsOverlay) view).homeTeamText.Text = homeName;
                    ((LeagueOfLegendsOverlay) view).homeTeamScoreText.Text = homeScore.ToString();
                    ((LeagueOfLegendsOverlay) view).awayTeamText.Text = awayName;
                    ((LeagueOfLegendsOverlay) view).awayTeamScoreText.Text = awayScore.ToString();
                    ((LeagueOfLegendsOverlay) view).seriesTypeText.Text = series.ToString();
                    ((LeagueOfLegendsOverlay) view).gameNumberText.Text = gameNumber();
                    break;
                }
            }

            if(!isVisable) activate();
        }

        private string gameNumber()
        {
            return (homeScore >= (int)series) || (awayScore >= (int)series) ? "Final" : $"Game {homeScore + awayScore + 1}";
        }

        private void activate()
        {
            view.Title = $"Series Score Overlay - {game}";
            view.Show();
            isVisable = true;
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
