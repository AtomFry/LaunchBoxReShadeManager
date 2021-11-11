using LaunchBoxReShadeManager.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LaunchBoxReShadeManager.Plugins
{
    class GameLaunchingReShadeManager : IGameLaunchingPlugin
    {
        public void OnAfterGameLaunched(IGame game, IAdditionalApplication app, IEmulator emulator)
        {
            // intentionally left blank
        }

        public void OnBeforeGameLaunching(IGame game, IAdditionalApplication app, IEmulator emulator)
        {
            try
            {
                string emulatorApplicationFolder = string.Empty;
                string gameApplicationFolder = string.Empty;
                string destinationFolder = string.Empty;

                // resolve emulator's parent folder
                if (!string.IsNullOrWhiteSpace(emulator?.ApplicationPath))
                {
                    DirectoryInfo emulatorDirectoryInfo = Directory.GetParent(emulator.ApplicationPath);
                    emulatorApplicationFolder = emulatorDirectoryInfo.FullName;
                    
                    if(Directory.Exists(emulatorApplicationFolder))
                    {
                        destinationFolder = emulatorApplicationFolder;
                    }
                }

                // resolve game's parent folder
                if(string.IsNullOrWhiteSpace(destinationFolder))
                {
                    if (!string.IsNullOrWhiteSpace(game?.ApplicationPath))
                    {
                        DirectoryInfo gameDirectoryInfo = Directory.GetParent(game.ApplicationPath);
                        gameApplicationFolder = gameDirectoryInfo.FullName;

                        if (Directory.Exists(gameApplicationFolder))
                        {
                            destinationFolder = gameApplicationFolder;
                        }
                    }
                }

                if (!Directory.Exists(destinationFolder))
                {
                    LogHelper.Log($"ReShade manager skipped for game ({game.Title}).  No emulator or game destination path was found.");
                    return;
                }

                // get the path to emulator specific ReShade folder 
                string safeEmulatorName = GetSafeWindowsName(emulator?.Title);                
                if (!string.IsNullOrWhiteSpace(safeEmulatorName))
                {
                    string emulatorReshadePath = Path.Combine(DirectoryInfoHelper.Instance.EmulatorsFolder, safeEmulatorName);                    
                    if (Directory.Exists(emulatorReshadePath))
                    {
                        FileCopyHelper.DirectoryCopy(emulatorReshadePath, destinationFolder, true);
                    }
                }

                // get the path to platform specific ReShade folder 
                string safePlatformName = GetSafeWindowsName(game?.Platform);                
                if (!string.IsNullOrWhiteSpace(safePlatformName))
                {
                    string platformReshadePath = Path.Combine(DirectoryInfoHelper.Instance.PlatformsFolder, safePlatformName);                    
                    if (Directory.Exists(platformReshadePath))
                    {
                        FileCopyHelper.DirectoryCopy(platformReshadePath, destinationFolder, true);
                    }
                }

                // get the path to game specific ReShade folder 
                string safeGameName = GetSafeWindowsName(game?.Title);                
                if (!string.IsNullOrWhiteSpace(safeGameName))
                {
                    string gameReshadePath = Path.Combine(DirectoryInfoHelper.Instance.GamesFolder, safePlatformName, safeGameName);                    
                    if (Directory.Exists(gameReshadePath))
                    {
                        FileCopyHelper.DirectoryCopy(gameReshadePath, destinationFolder, true);
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogException(ex, $"OnBeforeGameLaunching: {game.Title}");
            }
        }

        public void OnGameExited()
        {
            // intentionally left blank
        }

        public static string GetSafeWindowsName(string originalString)
        {
            string safeWindowsName = originalString;

            if (!string.IsNullOrWhiteSpace(safeWindowsName))
            {
                foreach (char invalidChar in InvalidFileNameChars)
                {
                    safeWindowsName = safeWindowsName.Replace(invalidChar, '_');
                }
                return safeWindowsName;
            }
            return string.Empty;
        }

        public static char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
    }
}
