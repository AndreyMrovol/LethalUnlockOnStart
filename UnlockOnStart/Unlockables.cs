using System.Collections.Generic;

namespace UnlockOnStart
{

  public class Unlockables
  {
    public static Dictionary<string, bool> ShipUpgradesDictionary = new(){
        {"Teleporter", ConfigManager.Teleporter.Value},
        {"Inverse Teleporter", ConfigManager.InverseTeleporter.Value},
        {"Loud horn", ConfigManager.LoudHorn.Value},
        {"Signal translator", ConfigManager.SignalTranslator.Value},
    };

    public static Dictionary<string, bool> SuitDictionary = new(){
      {"Green suit", ConfigManager.Suits.Value},
      {"Hazard suit", ConfigManager.Suits.Value},
      {"Pajama suit", ConfigManager.Suits.Value},
    };

    public static Dictionary<string, int> ItemsDictionary = new(){
        {"Flashlight", ConfigManager.Flashlights.Value},
        {"Pro-flashlight", ConfigManager.ProFlashlights.Value},
        {"Walkie-talkie", ConfigManager.WalkieTalkies.Value},
        {"Lockpicker", ConfigManager.LockPickers.Value},
        {"Extension ladder", ConfigManager.ExtensionLadders.Value},
        {"Radar-booster", ConfigManager.RadarBoosters.Value},
        {"Spray paint", ConfigManager.SprayPaints.Value},
        {"Shovel", ConfigManager.Shovels.Value},
        {"Stun grenade", ConfigManager.StunGrenades.Value},
        {"Zap gun", ConfigManager.ZapGuns.Value},
    };

  }
}