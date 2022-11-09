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
        Bo9 = 5,
        None = int.MaxValue
    }

    public enum Game
    {
        RocketLeague,
        LeagueOfLegends,
        Valorant,
        //SmashUltimate,
        //Overwatch,
        //NBA2k,
        //FIFA
    }

    public class Scoreboard
    {
        private string _homeName, _awayName;
        public Series Series { get; set; }
        public Game Game { get; set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public bool Visable { get; private set; }
        private Window _view;

        public Scoreboard(string _homeName, string _awayName)
        {
            this._homeName = _homeName;
            this._awayName = _awayName;
            Series = Series.None;
            Game = Game.RocketLeague;
            HomeScore = 0;
            AwayScore = 0;
            Visable = false;
            _view = new Window();
        }

        public void Apply()
        {
            switch (Game)
            {
                case Game.RocketLeague:
                {
                    if (!Visable) _view = new RocketLeagueOverlay();
                    ((RocketLeagueOverlay)_view).homeTeamText.Text = _homeName;
                    ((RocketLeagueOverlay)_view).homeTeamScoreText.Text = HomeScore.ToString();
                    ((RocketLeagueOverlay)_view).awayTeamText.Text = _awayName;
                    ((RocketLeagueOverlay)_view).awayTeamScoreText.Text = AwayScore.ToString();
                    ((RocketLeagueOverlay)_view).seriesTypeText.Text = seriesString();
                    ((RocketLeagueOverlay)_view).gameNumberText.Text = gameNumber();
                    break;
                }
                case Game.LeagueOfLegends:
                {
                    if (!Visable) _view = new LeagueOfLegendsOverlay();
                    ((LeagueOfLegendsOverlay)_view).homeTeamText.Text = _homeName;
                    ((LeagueOfLegendsOverlay)_view).homeTeamScoreText.Text = HomeScore.ToString();
                    ((LeagueOfLegendsOverlay)_view).awayTeamText.Text = _awayName;
                    ((LeagueOfLegendsOverlay)_view).awayTeamScoreText.Text = AwayScore.ToString();
                    ((LeagueOfLegendsOverlay)_view).seriesTypeText.Text = seriesString();
                    ((LeagueOfLegendsOverlay)_view).gameNumberText.Text = gameNumber();
                    break;
                }
                case Game.Valorant:
                {
                    if (!Visable) _view = new ValorantOverlay();
                    ((ValorantOverlay)_view).homeTeamText.Text = _homeName;
                    ((ValorantOverlay)_view).homeTeamScoreText.Text = HomeScore.ToString();
                    ((ValorantOverlay)_view).awayTeamText.Text = _awayName;
                    ((ValorantOverlay)_view).awayTeamScoreText.Text = AwayScore.ToString();
                    ((ValorantOverlay)_view).seriesTypeText.Text = seriesString();
                    ((ValorantOverlay)_view).gameNumberText.Text = gameNumber();
                    break;
                }
            }

            if(!Visable) activate();
        }

        public void Clear()
        {
            if (Visable)
            {
                _view.Close();
                Visable = false;
            }

            HomeScore = 0;
            AwayScore = 0;
        }

        public void ChangeName(Team team, string name)
        {
            name = name.ToUpper();

            if(team == Team.Home) _homeName = name;
            else _awayName = name;
        }

        public void AddScore(Team team)
        {
            if (!Visable) return;

            int MAX_SCORE = (int) Series;

            if ((team == Team.Home) && (HomeScore + 1 <= MAX_SCORE)) HomeScore++;
            if ((team == Team.Away) && (AwayScore + 1 <= MAX_SCORE)) AwayScore++;
        }

        public void RemoveScore(Team team)
        {
            if (!Visable) return;

            if (team == Team.Home && HomeScore > 0) HomeScore--;
            else if (AwayScore > 0) AwayScore--;
        }

        private string seriesString()
        {
            return Series == Series.None ? "N/A" : Series.ToString(); 
        }

        private string gameNumber()
        {
            return (HomeScore >= (int)Series) || (AwayScore >= (int)Series) ? "FINAL" : $"GAME {HomeScore + AwayScore + 1}";
        }

        private void activate()
        {
            _view.Title = $"Series Score Overlay - {Game}";
            _view.Show();
            Visable = true;
        }
    }
}
