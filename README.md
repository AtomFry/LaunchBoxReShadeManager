# LaunchBoxReShadeManager
LaunchBoxReShadeManager is a plugin for LaunchBox and BigBox that copies ReShade configuration files to emulator folders when a game starts. The intention of this plug-in is to use a special version of ReShade which can display bezels on emulators that do not have bezel support like Citra, Cxbx-Reloaded, Demul, Dolphin, DuckStation, Model 2, PCSX2, Supermodel, TeknoParrot, and Xemu. To use a bezel with these emulators, ReShade configuration files and the bezel file must be present in the emulator folder with a specific folder structure. The plug-in automates this by copying the needed files from the plug-in configuration folder to the emulator folder when a game starts.

# Installation

Download LaunchBoxReShadeManager.zip
Extract the zip folder
Copy the LaunchBoxReShadeManager and Plugins folders to the root of your LaunchBox directory

The ReShade configuration files must be present in a folder called LaunchBoxReShadeManager which resides at the root of the LaunchBox directory. The plug-in supports three levels of ReShade configuration:

# Emulator
These files include both the ReShade configuration and the default bezel for the emulator. This allows for a default configuration at the emulator level. The system will copy any files in a folder with the name of an emulator to the emulator directory if it exists at the following location:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for emulators{EMULATOR}

Where {EMULATOR} is the safe name of the emulator. These emulator names must match the name of the emulator as it is setup in your LaunchBox instance. You can change the folder names in this path to match the naming of your emulator if you have an emulator named differently.

# Platform
This allows for overrides at the platform level. The system will copy any files in a folder with the name of a platform to the emulator directory if it exists at the following location:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for platforms{PLATFORM}

Where {PLATFORM} is the safe name of the platform. These platform names must match the name of the platform as it is setup in your LaunchBox instance. You can set the folder names in this path to match the naming of your platform if you have a platform named differently.

# Game
This allows for overrides at the game level. The system will copy any files in a folder with the name of a game to the emulator directory if it exists at the following location:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games{PLATFORM}{GAME}

Where {PLATFORM} is the safe name of the platform
Where {GAME} is the safe name of the game

# Notes on safe names
Some characters (like /:?*?"<>|) are invalid in file and folder names. If these files exist in the emulator, platform, or game name, those characters must be replaced by an underscore. For example, to create a game specific override for the game "Castlevania: The Adventure ReBirth", create a folder in the following location and add your ReShade files:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\Nintendo Wii\Castlevania_ The Adventure ReBirth

# Adding a custom bezel for a game or platform
ReShade expects a specific file path and file name for bezels. The file name and folder structure is important when adding a custom bezel for a game or platform so that the plug-in can copy the file to the correct location and ReShade can properly display it. Use the following examples for guidance when adding custom bezel overrides at the platform or game level

Example path for adding a bezel for any Nintendo Gamecube game:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for platforms\Nintendo Gamecube\reshade-shaders\Textures\Bezel.png

Example path for adding a bezel override for the Nintendo Gamecube game titled Alien Hominid
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\Nintendo Gamecube\Alien Hominid\reshade-shaders\Textures\Bezel.png

# Special thanks
nohero
ReShade developers (to be identified)
