This is Pixel Legend. A 2d platformer game. Final version made on 2/10/2025

This project can be accessed by downloading:

1. Unity hub
2. Unity 2022.3.3f1
3. VScode

Follow the steps below to access the game:

1. Clone the project to a folder. Go to unity and click Add.
2. Click Add from disk, then add the project file.
3. Load project file

Overview of Project:

The asset file has everything needed to edit the game:

1. Animations: Includes animations of all objects in game.
2. Casual Game Sounds U6: A downloaded folder with game music in it.
3. CasualGameBGM05: Background music options
4. Fonts: Has a few selections for font option for the game.
5. Music: Has more backgound music options.
6. Pixel Adventure 1: Has all art assets, in case you want to add more features. Has tons of unused art.
7. Pixel Font-TripFive: Has unused fonts due to not working with legacy text.
8. Prefabs: Includes every trap and object, you can drag and drop to add stuff to the game or make your own level.
9. Scenes: This is where all the levels are, you can select one to play. You can also add one from here.
10. Scripts: Includes all scripts.
11. TextMeshPro: Type of text other than legacy text. Tried. Did not work.

Scripts folder inside Asset folder has all scripts:
    Camera:
        1. CameraController: Makes sure camera moves with player
    Items:
        1. StickyPlatform: Makes sure player cannot fall of platform while on it.
        2. WaypointFollower: Makes sure saws and moving platforms move.
        3. EndFlag: Teleports you to next level
        4. ItemController: Collects apples and adds them to the text above the screen.
    Player:
        1. PlayerMovement: Manages all movement for players.
        2. PlayerLife: Handles player life and kills if player is touching trap or falling off the edge and reaching certain y level.

This is how to manage and edit the game:

1. Making a new Level: Go to scenes and make a new level called Level 3. Add to build manager and make the level using tile pallete.

2. Making new object : Create new 2d object. Go to Pixel Adventure 1 and get assets from there to put in sprite renderer and create an animation. Make the script for the object. Go to Animator to set when to use the animation and create box colliders. Label the tag appropriately and put in correct folders or create new ones.