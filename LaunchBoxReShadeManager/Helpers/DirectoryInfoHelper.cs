using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LaunchBoxReShadeManager.Helpers
{
    public sealed class DirectoryInfoHelper
    {
        private static readonly DirectoryInfoHelper instance = new DirectoryInfoHelper();

        // path to the big box application directory
        private string applicationPath;
        public string ApplicationPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(applicationPath))
                {
                    applicationPath = Directory.GetCurrentDirectory();
                }

                return applicationPath;
            }
        }

        // path to launchbox images folder 
        private string launchboxImagesPath;
        public string LaunchboxImagesPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(launchboxImagesPath))
                {
                    launchboxImagesPath = $"{ApplicationPath}\\Images";
                }

                return launchboxImagesPath;
            }
        }

        private string launchboxImagesPlatformsPath;
        public string LaunchboxImagesPlatformsPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(launchboxImagesPlatformsPath))
                {
                    launchboxImagesPlatformsPath = $"{LaunchboxImagesPath}\\Platforms";
                }
                return launchboxImagesPlatformsPath;
            }
        }

        private string pluginFolder;
        public string PluginFolder
        {
            get
            {
                if (string.IsNullOrWhiteSpace(pluginFolder))
                {
                    pluginFolder = $"{ApplicationPath}\\ReShadeManager";
                }
                return pluginFolder;
            }
        }

        private string logFile;
        public string LogFile
        {
            get
            {
                if(string.IsNullOrWhiteSpace(logFile))
                {
                    logFile = $"{PluginFolder}\\log.txt";
                }
                return logFile;
            }
        }

        private string emulatorsFolder;
        public string EmulatorsFolder
        {
            get
            {
                if(string.IsNullOrWhiteSpace(emulatorsFolder))
                {
                    emulatorsFolder = $"{PluginFolder}\\Emulators";
                }
                return emulatorsFolder;
            }
        }

        private string platformsFolder;
        public string PlatformsFolder
        {
            get
            {
                if (string.IsNullOrWhiteSpace(platformsFolder))
                {
                    platformsFolder = $"{PluginFolder}\\Platforms";
                }
                return platformsFolder;
            }
        }

        private string gamesFolder;
        public string GamesFolder
        {
            get
            {
                if (string.IsNullOrWhiteSpace(gamesFolder))
                {
                    gamesFolder = $"{PluginFolder}\\Games";
                }
                return gamesFolder;
            }
        }



        private string bigBoxSettingsFile;
        public string BigBoxSettingsFile
        {
            get
            {
                if (string.IsNullOrWhiteSpace(BigBoxSettingsFile))
                {
                    bigBoxSettingsFile = $"{ApplicationPath}\\Data\\BigBoxSettings.xml";
                }
                return bigBoxSettingsFile;
            }
        }

        private string launchBoxSettingsFile;
        public string LaunchBoxSettingsFile
        {
            get
            {
                if (string.IsNullOrWhiteSpace(launchBoxSettingsFile))
                {
                    launchBoxSettingsFile = $"{ApplicationPath}\\Data\\Settings.xml";
                }
                return launchBoxSettingsFile;
            }
        }


        public static void CreateFolders()
        {
            CreateFolder(DirectoryInfoHelper.Instance.PluginFolder);           
        }

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string ResourceFolder
        {
            get
            {
                return "pack://application:,,,/ReShadeManager;component/resources";
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DirectoryInfoHelper()
        {
        }

        private DirectoryInfoHelper()
        {

        }

        public static DirectoryInfoHelper Instance
        {
            get
            {
                return instance;
            }
        }
    }


}
