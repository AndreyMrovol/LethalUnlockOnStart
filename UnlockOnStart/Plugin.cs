using System.IO;
using BepInEx;
using BepInEx.Configuration;
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

            ShipUpgradesConfigManager.Init(new ConfigFile(Path.Combine(Paths.ConfigPath, "UnlockOnStart/ShipUpgrades.cfg"), true));
            DecorationsConfigManager.Init(new ConfigFile(Path.Combine(Paths.ConfigPath, "UnlockOnStart/Decorations.cfg"), true));
            ItemsConfigManager.Init(new ConfigFile(Path.Combine(Paths.ConfigPath, "UnlockOnStart/Items.cfg"), true));
            ConfigManager.Init(new ConfigFile(Path.Combine(Paths.ConfigPath, "UnlockOnStart/General.cfg"), true));

            logger = Logger;
            harmony.PatchAll();

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}