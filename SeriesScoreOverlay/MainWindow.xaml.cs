﻿using SeriesScoreOverlay.Hotkeys;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SeriesScoreOverlay
{
    public partial class MainWindow : Window
    {
        private Scoreboard _scoreboard;

        public MainWindow()
        {
            InitializeComponent();
            _scoreboard = new Scoreboard(homeTextBox.Text, awayTextBox.Text);

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
            _scoreboard.Game = (Game)gameSelectionComboBox.SelectedItem;
        }

        private void homeAddButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.AddScore(Team.Home);
            homeScore.Content = _scoreboard.HomeScore;
        }

        private void homeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.RemoveScore(Team.Home);
            homeScore.Content = _scoreboard.HomeScore;
        }

        private void awayAddButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.AddScore(Team.Away);
            awayScore.Content = _scoreboard.AwayScore;
        }

        private void awayRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.RemoveScore(Team.Away);
            awayScore.Content = _scoreboard.AwayScore;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.ChangeName(Team.Home, homeTextBox.Text);
            _scoreboard.ChangeName(Team.Away, awayTextBox.Text);
            _scoreboard.Series = (Series)seriesTypeComboBox.SelectedItem;
            _scoreboard.Apply();
            applyButton.Content = "Apply";
            clearButton.IsEnabled = true;
            gameSelectionComboBox.IsEnabled = false;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _scoreboard.Clear();
            applyButton.Content = "Launch";
            awayScore.Content = _scoreboard.AwayScore;
            homeScore.Content = _scoreboard.HomeScore;
            clearButton.IsEnabled = false;
            gameSelectionComboBox.IsEnabled = true;
        }
    }
}
