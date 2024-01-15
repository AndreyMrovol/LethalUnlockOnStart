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

    public static Dictionary<string, bool> DecorationDictionary = new(){
      {"Cozy lights", ConfigManager.CozyLights.Value},
      {"Television", ConfigManager.Television.Value},
      {"Toilet", ConfigManager.Toilet.Value},
      {"Shower", ConfigManager.Shower.Value},
      {"Record player", ConfigManager.RecordPlayer.Value},
      {"Table", ConfigManager.Table.Value},
      {"Romantic table", ConfigManager.RomanticTable.Value},
      {"JackOLantern", ConfigManager.JackOLantern.Value},
      {"Welcome mat", ConfigManager.WelcomeMat.Value},
      {"Goldfish", ConfigManager.Goldfish.Value},
      {"Plushie pajama", ConfigManager.PlushiePajama.Value}
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

        {"Shotgun", ConfigManager.Shotgun.Value},
        {"Shotgun shells", ConfigManager.ShotgunShells.Value},

        {"Jetpack", ConfigManager.Jetpacks.Value},
        {"TZP-Inhalant", ConfigManager.Inhalants.Value},
    };

  }
}