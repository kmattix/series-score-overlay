using SeriesScoreOverlay.Hotkeys;
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

            foreach (SeriesType st in Enum.GetValues(typeof(SeriesType)))
            {
                seriesTypeComboBox.Items.Add(st);
            }
            seriesTypeComboBox.SelectedIndex = 0;

            HotkeysManager.SetupSystemHook();
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.F5, () => hkPressed(Team.Home, true)));
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.F7, () => hkPressed(Team.Home, false)));
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.F6, () => hkPressed(Team.Away, true)));
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.F8, () => hkPressed(Team.Away, false)));
            Closing += MainWindow_Closing;
        }

        private void hkPressed(Team team, bool add)
        {
            if (team == Team.Home && add) homeAddButton_Click(null, new RoutedEventArgs());
            else if (team == Team.Home && !add) homeRemoveButton_Click(null, new RoutedEventArgs());
            else if (team == Team.Away && add) awayAddButton_Click(null, new RoutedEventArgs());
            else if (team == Team.Away && !add) awayRemoveButton_Click(null, new RoutedEventArgs());
            applyButton_Click(null, new RoutedEventArgs());
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HotkeysManager.ShutdownSystemHook();
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
            scoreboard.seriesType = (SeriesType)seriesTypeComboBox.SelectedItem;
            scoreboard.apply();
            applyButton.Content = "Apply";
            clearButton.IsEnabled = true;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.clear();
            applyButton.Content = "Launch";
            awayScore.Content = scoreboard.awayScore;
            homeScore.Content = scoreboard.homeScore;
            clearButton.IsEnabled = false;
        }
    }
}
