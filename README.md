# series-score-overlay
**WORK-IN-PROGRESS**

Stream scoreboard overlay to track a games series. Currently Rocket League, League of Legends, and Valorant are officially supported with Bo1-9 and None modes. This overlay can be used with any other game, but it might conflict with game UI.

## todo
* Add close handler for when X is pressed on the overlay window.
* Add UI changes in the control panel to show when the overlay has not been aplied.
  - Specific elements should be bolded or otherwise when they have unapplied changes.
  - Add buttons
  - Remove buttons
  - Team names
  - Series type
* Add support for other games:
  - Overwatch
  - Smash Ultimate
  - NBA2k
  - FIFA
* Add ability to change the background for more chromakey compatability.
* ~~Change overlay design to something better~~ (kind of finished, but could always be better)

## running the app
  1. Go to [Releases](https://github.com/kmattix/series-score-overlay/releases).
  2. Select the most recent `Tag`.
  3. Follow the `Setup` steps.

## building the app for release
 1. Open a CLI in `series-score-overlay/SeriesScoreOverlay` or whever your solution is located.
 2. Run `dotnet publish -c Release --self-contained -r win-x64 -p:PublishSingleFile=true`.
 3. Navigate to `series-score-overlay\SeriesScoreOverlay\obj\Release\net6.0-windows\publish` and all the publishable files are located in this directory.
