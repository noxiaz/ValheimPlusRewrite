using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite
{
    internal static class Log
    {
        private static ManualLogSource logger;
        public static void Initialize(ManualLogSource logger)
        {
            Log.logger = logger;
            LogInfo($"ValheimPlus Loaded!");
            LogInfo($"INFO LOG LOADED");
            LogDebug($"DEBUG LOG LOADED");
            LogWarning($"WARNING LOG LOADED");
            LogError($"ERROR LOG LOADED");
            LogFatal($"FATAL LOG LOADED");
        }

        public static void LogFatal(object data) => logger.LogFatal(data);
        public static void LogError(object data) => logger.LogError(data);
        public static void LogWarning(object data) => logger.LogWarning(data);
        public static void LogMessage(object data) => logger.LogMessage(data);
        public static void LogInfo(object data) => logger.LogInfo(data);
        public static void LogDebug(object data) => logger.LogDebug(data);

    }
}
