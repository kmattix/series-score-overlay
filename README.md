# series-score-overlay
**WORK-IN-PROGRESS**

Stream scoreboard overlay to track a games series. Currently the only officially supported game is Rocket League with Bo1-9 and None modes.

## todo
* Add close handler for when X is pressed on the overlay window.
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
