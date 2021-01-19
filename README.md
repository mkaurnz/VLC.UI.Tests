# VLC.UI.Tests

## Introduction

This project is testing VLC media player by running UI Tests through Appium and Windows app driver. 

## Design Process

To design these tests I went through the following steps
1. Make sure all the pre-requisites are installed:
    * VLC media player
    * A sample media file
    * Visual studio
    * WinAppDriver
    * Inspect.exe
    
2. Did a manual run through the scenario and took a rough note of all the UI interactions and also took notes as to how things appear and get focused automatically after certain actions.

3. Then I used the `inspect.exe` to find locators of most of the elements involved.

4. At this stage I had a good Idea as to what I needed to do and So I wrote a rough test plan which I was going to automate.

5. Then I created a new .Net core unit test project using NUnit and started implementing the above test plan.

## How to run tests
1. Run WinAppDriver by running `C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe`
2. Add a media file called `test.mp4` in `C:\temp` location.
3. Open the solution in Visual studio.
4. Open `VLCTests.cs` file and right click on `PlaylistSearchTest` method and select `Run Tests`.


## UI automation design pattern
Different parts functionality is divided into different methods which makes the tests easy to understand. 

Next step from this approach will be the `Page Object Model` design pattern. In that approach we will have a different class to handle functionality of each page in the application. 




