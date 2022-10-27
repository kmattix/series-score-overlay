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
        Scoreboard scoreboard;
        public MainWindow()
        {
            InitializeComponent();
            scoreboard = new Scoreboard(homeTextBox.Text, awayTextBox.Text);
        }

        private void homeAddButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.addHomeScore();
            homeScore.Content = scoreboard.getHomeScore();
        }

        private void homeSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeHomeScore();
            homeScore.Content = scoreboard.getHomeScore();
        }

        private void awayAddButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.addAwayScore();
            awayScore.Content = scoreboard.getAwayScore();
        }

        private void awaySubtractButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeAwayScore();
            awayScore.Content = scoreboard.getAwayScore();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.clear();
            awayScore.Content = scoreboard.getAwayScore();
            homeScore.Content = scoreboard.getHomeScore();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.changeHomeName(homeTextBox.Text);
            scoreboard.changeAwayName(awayTextBox.Text);
            scoreboard.apply();
        }
    }
}
