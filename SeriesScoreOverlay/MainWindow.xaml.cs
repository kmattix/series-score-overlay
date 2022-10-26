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
        }

        private void homeSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeHomeScore();
        }

        private void awayAddButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.addAwayScore();
        }

        private void awaySubtractButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.removeAwayScore();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.clear();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.changeHomeName(homeTextBox.Text);
            scoreboard.changeAwayName(awayTextBox.Text);
            scoreboard.apply();
        }
    }
}
