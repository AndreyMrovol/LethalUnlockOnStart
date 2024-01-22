using System.Collections.Generic;

namespace UnlockOnStart
{

  public class Unlockables
  {
    public static Dictionary<string, bool> ShipUpgradesDictionary = new(){
        {"Teleporter", ShipUpgradesConfigManager.Teleporter.Value},
        {"Inverse Teleporter", ShipUpgradesConfigManager.InverseTeleporter.Value},
        {"Loud horn", ShipUpgradesConfigManager.LoudHorn.Value},
        {"Signal translator", ShipUpgradesConfigManager.SignalTranslator.Value},
    };

    public static Dictionary<string, bool> SuitDictionary = new(){
      {"Green suit", DecorationsConfigManager.Suits.Value},
      {"Hazard suit", DecorationsConfigManager.Suits.Value},
      {"Pajama suit", DecorationsConfigManager.Suits.Value},
    };

    public static Dictionary<string, bool> DecorationDictionary = new(){
      {"Cozy lights", DecorationsConfigManager.CozyLights.Value},
      {"Television", DecorationsConfigManager.Television.Value},
      {"Toilet", DecorationsConfigManager.Toilet.Value},
      {"Shower", DecorationsConfigManager.Shower.Value},
      {"Record player", DecorationsConfigManager.RecordPlayer.Value},
      {"Table", DecorationsConfigManager.Table.Value},
      {"Romantic table", DecorationsConfigManager.RomanticTable.Value},
      {"JackOLantern", DecorationsConfigManager.JackOLantern.Value},
      {"Welcome mat", DecorationsConfigManager.WelcomeMat.Value},
      {"Goldfish", DecorationsConfigManager.Goldfish.Value},
      {"Plushie pajama man", DecorationsConfigManager.PlushiePajama.Value}
    };

    public static Dictionary<string, int> ItemsDictionary = new(){
        {"Flashlight", ItemsConfigManager.Flashlights.Value},
        {"Pro-flashlight", ItemsConfigManager.ProFlashlights.Value},
        {"Walkie-talkie", ItemsConfigManager.WalkieTalkies.Value},
        {"Lockpicker", ItemsConfigManager.LockPickers.Value},
        {"Extension ladder", ItemsConfigManager.ExtensionLadders.Value},
        {"Radar-booster", ItemsConfigManager.RadarBoosters.Value},
        {"Spray paint", ItemsConfigManager.SprayPaints.Value},
        {"Shovel", ItemsConfigManager.Shovels.Value},
        {"Stun grenade", ItemsConfigManager.StunGrenades.Value},
        {"Zap gun", ItemsConfigManager.ZapGuns.Value},

        {"Shotgun", ItemsConfigManager.Shotgun.Value},
        {"Ammo", ItemsConfigManager.ShotgunShells.Value},

        {"Jetpack", ItemsConfigManager.Jetpacks.Value},
        {"TZP-Inhalant", ItemsConfigManager.Inhalants.Value},
    };

  }
}