using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace UnlockOnStart
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private readonly Harmony harmony = new("UnlockOnStart");

        private void Awake()
        {
            ConfigManager.Init(Config);

            logger = Logger;
            harmony.PatchAll();

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}