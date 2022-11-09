using SeriesScoreOverlay.Hotkeys;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SeriesScoreOverlay
{
    public partial class MainWindow : Window
    {
        private Scoreboard scoreboard;

        public MainWindow()
        {
            InitializeComponent();
            scoreboard = new Scoreboard(homeTextBox.Text, awayTextBox.Text);

            foreach (Series s in Enum.GetValues(typeof(Series)))
            {
                seriesTypeComboBox.Items.Add(s);
            }
            seriesTypeComboBox.SelectedIndex = Enum.GetValues(typeof(Series)).Length - 1;

            foreach (Game g in Enum.GetValues(typeof(Game)))
            {
                gameSelectionComboBox.Items.Add(g);
            }
            gameSelectionComboBox.SelectedIndex = 0;

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

        private void gameSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scoreboard.game = (Game)gameSelectionComboBox.SelectedItem;
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
            scoreboard.series = (Series)seriesTypeComboBox.SelectedItem;
            scoreboard.apply();
            applyButton.Content = "Apply";
            clearButton.IsEnabled = true;
            gameSelectionComboBox.IsEnabled = false;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            scoreboard.clear();
            applyButton.Content = "Launch";
            awayScore.Content = scoreboard.awayScore;
            homeScore.Content = scoreboard.homeScore;
            clearButton.IsEnabled = false;
            gameSelectionComboBox.IsEnabled = true;
        }
    }
}
