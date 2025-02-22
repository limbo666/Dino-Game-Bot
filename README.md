# **Dino Game Bot**
A simple bot written in vb.net to automatically play the Chrome Dino game by detecting obstacles on the screen and simulating key presses to jump over them.
This project uses screen capture techniques to analyze pixel brightness and detect cacti in the game, triggering an "UP arrow" key press to make the dinosaur jump. It’s designed for the offline Chrome Dino game (chrome://dino) or similar browser-based versions.
![dino1](https://github.com/user-attachments/assets/a4e323f6-fe5a-40c6-b733-cab8356e3421)

### Features
-   Screen Color Detection: Captures pixel data from the screen to detect obstacles.
-   Automated Jumping: Simulates the UP arrow key press to jump over cacti.
-   Configurable Detection Points: Allows users to set custom background and detection points via mouse clicks.
-   Real-Time Feedback: Displays background and detection brightness values, with a visual indicator (lblkick) for jump triggers.
    

### Prerequisites
-   Operating System: Windows (tested on Windows 10/11).
-   Development Environment: Visual Studio (with VB.NET support).
-   Browser: Chrome or Brave with hardware acceleration disabled (see Troubleshooting (#troubleshooting)).
-   .NET Framework: Version 4.5 or higher.
  


### Usage
1.  Run the Application:
    -   Start the built executable from Visual Studio or the bin\Debug folder.
2.  Set Detection Points:
    -   Click Set Background Point and left-click a spot on the game’s background (e.g., the sky or ground).
    -   Click Set Detection Point and left-click a spot just in front of the dinosaur where cacti will appear.
    -   Coordinates are displayed in lblBackgroundPoint and lblDetectionPoint.
3.  Start the Bot:
    -   Click Start to begin detection. The bot will monitor the screen and jump when obstacles are detected.
    -   lblStatus shows real-time brightness values (BG for background, DetectAvg for detection area).
    -   lblkick turns red when a jump is triggered.
4.  Stop or Reset:
    -   Click Stop to pause the bot.
     -   Click Reset to clear the points and set new ones.

### How It Works
-   Screen Capture: Uses Graphics.CopyFromScreen to capture a 20x20 pixel region around the detection point and a single pixel for the background.
    -   Brightness Calculation: Computes brightness using the formula: 0.299R + 0.587G + 0.114B.
    -   Obstacle Detection: Averages brightness over a 10x10 central area of the detection region. If the average drops below 200 (indicating a dark obstacle like a cactus), it triggers a jump.
 -   Key Simulation: Sends an UP arrow key press via keybd_event to make the dinosaur jump.
    

### Configuration
-   Timer Interval: Set to 2ms (~500 FPS) in Form1_Load. Adjust if performance lags (e.g., tmrDetection.Interval = 5 for 200 FPS).
    -   Detection Threshold: Currently set to detectBrightnessAvg < 200. Modify in tmrDetection_Tick based on your game’s brightness values (check lblStatus for real-time data).
    -   Detection Area: Uses a 20x20 pixel region with a 10x10 central average. Adjust the Bitmap size or loop range in tmrDetection_Tick for larger/smaller areas.
    

### Troubleshooting
-   No Detection in Browser: Ensure hardware acceleration is disabled in Chrome/Brave. Restart the browser after changing this setting.
-   Missed Obstacles: Adjust the detection point (move it right) or lower the brightness threshold (e.g., < 150) if cacti aren’t detected.
-   No Jumps: Verify the browser is in focus. Add focus logic if needed (e.g., SetForegroundWindow).
-   Performance Issues: Increase the timer interval (e.g., 5ms) if the CPU struggles with 2ms.
  

### Future Improvements
-   Dynamic threshold adjustment for day/night modes in the Dino game.
-   Multi-point detection for better obstacle anticipation.
-   Support for ducking under pterodactyls (down arrow key).
-   Save/load detection point coordinates.
    

### Contributing
Feel free to fork this repository, submit issues, or create pull requests with enhancements!
### License
This project is open-source and available under the MIT License (LICENSE).
