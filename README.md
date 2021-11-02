# LaunchBoxReShadeManager
LaunchBoxReShadeManager is a plugin for LaunchBox and BigBox that copies ReShade configuration files to emulator folders when a game starts. The intention of this plug-in is to use a special version of ReShade which can display bezels on emulators that do not have bezel support like Citra, Cxbx-Reloaded, Demul, Dolphin, DuckStation, Model 2, PCSX2, Supermodel, TeknoParrot, and Xemu. To use a bezel with these emulators, ReShade configuration files and the bezel file must be present in the emulator folder with a specific folder structure. The plug-in automates this by copying the needed files from the plug-in configuration folder to the emulator folder when a game starts.

# Installation
Download LaunchBoxReShadeManager.zip  
Extract the to a local zip folder  
Copy the LaunchBoxReShadeManager and Plugins folders to the root of your LaunchBox directory.  
IMPORTANT - TheLaunchBoxReShadeManager folder must reside in the root of the LaunchBox directory  

# Emulator settings
These files are included in the plug-in ZIP file.  They include both the ReShade configuration and the default bezel for the emulator. This allows for a default configuration at the emulator level. The system will copy any files in a folder with the name of an emulator to the emulator directory if it exists at the following location:  
  
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for emulators\\{EMULATOR}  
  
Where {EMULATOR} is the safe name (more on "safe names" below) of the emulator. These emulator names must match the name of the emulator as it is setup in your LaunchBox instance. You can change the folder names in this path to match the naming of your emulator if you have an emulator named differently.  
  
You can replace the default bezel for an emulator by replacing the Bezel.png file at the following path:  
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for emulators\\{EMULATOR}\reshade-shaders\Textures\Bezel.png

# Platform settings
You can override ReShade settings and bezels at the platform level. The system will copy any files in a folder with the name of a platform to the emulator directory if it exists at the following location:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for platforms\\{PLATFORM}

Where {PLATFORM} is the safe name (more on "safe names" below) of the platform. These platform names must match the name of the platform as it is setup in your LaunchBox instance. You can set the folder names in this path to match the naming of your platform if you have a platform named differently.

You can replace the bezel for a platform by replacing the Bezel.png file at the following path: 
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for platforms\\{PLATFORM}\reshade-shaders\Textures\Bezel.png  
  
Example path for adding a default bezel for Nintendo Gamecube games:  
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for platforms\Nintendo Gamecube\reshade-shaders\Textures\Bezel.png

# Game settings
You can override ReShade settings and bezels at the game level.  The system will copy any files in a folder with the name of a game to the emulator directory if it exists at the following location:  

..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\\{PLATFORM}\\{GAME}  
  
Where {PLATFORM} is the safe name (more on "safe names" below) of the platform  
Where {GAME} is the safe name (more on "safe names" below) of the game  

You can replace the bezel for a game by replacing the Bezel.png file at the following path:  
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\\{PLATFORM}\\{GAME}\\reshade-shaders\Textures\Bezel.png  
  
Example path for adding a bezel override for the Nintendo Gamecube game titled Alien Hominid  
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\Nintendo Gamecube\Alien Hominid\reshade-shaders\Textures\Bezel.png  

# Notes on safe names
Some characters (like /:?*?"<>|) are invalid in file and folder names. If these files exist in the emulator, platform, or game name, those characters must be replaced by an underscore. For example, to create a game specific override for the game "Castlevania: The Adventure ReBirth", create a folder in the following location and add your ReShade files:
..\LaunchBox\LaunchBoxReShadeManager\ReShade versions for games\Nintendo Wii\Castlevania_ The Adventure ReBirth

# Special thanks
nohero
ReShade developers (to be identified)
