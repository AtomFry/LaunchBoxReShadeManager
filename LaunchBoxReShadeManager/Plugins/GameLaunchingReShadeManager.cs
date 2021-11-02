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
                // resolve path to emulator - we need to copy files here - just use emulator.ApplicationPath
                if (string.IsNullOrWhiteSpace(emulator?.ApplicationPath))
                {
                    LogHelper.Log($"ReShade manager skipped for game ({game.Title}).  Emulator application path is null.");
                    return;
                }

                if (!File.Exists(emulator?.ApplicationPath))
                {
                    LogHelper.Log($"ReShade manager skipped for game ({game.Title}).  Emulator application does not exist.");
                    return;
                }

                DirectoryInfo emulatorDirectoryInfo = Directory.GetParent(emulator.ApplicationPath);
                string emulatorApplicationFolder = emulatorDirectoryInfo.FullName;
                if (!Directory.Exists(emulatorApplicationFolder))
                {
                    LogHelper.Log($"ReShade manager skipped for game ({game.Title}).  Emulator path does not exist.");
                    return;
                }

                // get the path to emulator specific ReShade folder 
                string safeEmulatorName = GetSafeWindowsName(emulator?.Title);
                string emulatorReshadePath = Path.Combine(DirectoryInfoHelper.Instance.EmulatorsFolder, safeEmulatorName);
                FileCopyHelper.DirectoryCopy(emulatorReshadePath, emulatorApplicationFolder, true);

                // get the path to platform specific ReShade folder 
                string safePlatformName = GetSafeWindowsName(game?.Platform);
                string platformReshadePath = Path.Combine(DirectoryInfoHelper.Instance.PlatformsFolder, safePlatformName);
                FileCopyHelper.DirectoryCopy(platformReshadePath, emulatorApplicationFolder, true);

                // get the path to game specific ReShade folder 
                string safeGameName = GetSafeWindowsName(game?.Title);
                string gameReshadePath = Path.Combine(DirectoryInfoHelper.Instance.GamesFolder, safePlatformName, safeGameName);
                FileCopyHelper.DirectoryCopy(gameReshadePath, emulatorApplicationFolder, true);
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
