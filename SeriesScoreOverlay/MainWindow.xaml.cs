using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeriesScoreOverlay
{
    public partial class MainWindow : Window
    {
        private Scoreboard scoreboard;

        public MainWindow()
        {
            InitializeComponent();
            scoreboard = new Scoreboard(homeTextBox.Text, awayTextBox.Text);
        }

        private void homeAddButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.addScore(Team.Home);
            homeScore.Content = scoreboard.homeScore;
        }

        private void homeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeScore(Team.Home);
            homeScore.Content = scoreboard.homeScore;
        }

        private void awayAddButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.addScore(Team.Away);
            awayScore.Content = scoreboard.awayScore;
        }

        private void awayRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeScore(Team.Away);
            awayScore.Content = scoreboard.awayScore;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.changeName(Team.Home, homeTextBox.Text);
            scoreboard.changeName(Team.Away, awayTextBox.Text);
            scoreboard.apply();
            applyButton.Content = "Apply";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.clear();
            applyButton.Content = "Launch";
            awayScore.Content = scoreboard.awayScore;
            homeScore.Content = scoreboard.homeScore;
        }
    }
}
