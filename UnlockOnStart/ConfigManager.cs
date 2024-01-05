using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace UnlockOnStart;

public class ConfigManager
{
  public static ConfigManager Instance { get; private set; }

  public static void Init(ConfigFile config)
  {
    Instance = new ConfigManager(config);
  }

  public static ConfigEntry<bool> Teleporter { get; private set; }
  public static ConfigEntry<bool> InverseTeleporter { get; private set; }
  public static ConfigEntry<bool> LoudHorn { get; private set; }
  public static ConfigEntry<bool> SignalTranslator { get; private set; }

  public static ConfigEntry<int> Flashlights { get; private set; }
  public static ConfigEntry<int> ProFlashlights { get; private set; }

  public static ConfigEntry<int> WalkieTalkies { get; private set; }
  public static ConfigEntry<int> LockPickers { get; private set; }
  public static ConfigEntry<int> ExtensionLadders { get; private set; }
  public static ConfigEntry<int> RadarBoosters { get; private set; }
  public static ConfigEntry<int> SprayPaints { get; private set; }
  public static ConfigEntry<int> Jetpacks { get; private set; }


  public static ConfigEntry<int> Inhalants { get; private set; }


  public static ConfigEntry<int> Shovels { get; private set; }
  public static ConfigEntry<int> StunGrenades { get; private set; }
  public static ConfigEntry<int> ZapGuns { get; private set; }
  public static ConfigEntry<int> Shotgun { get; private set; }
  public static ConfigEntry<int> ShotgunShells { get; private set; }


  public static ConfigEntry<bool> CozyLights { get; private set; }
  public static ConfigEntry<bool> Television { get; private set; }
  public static ConfigEntry<bool> Toilet { get; private set; }
  public static ConfigEntry<bool> Shower { get; private set; }
  public static ConfigEntry<bool> RecordPlayer { get; private set; }
  public static ConfigEntry<bool> Table { get; private set; }
  public static ConfigEntry<bool> RomanticTable { get; private set; }
  public static ConfigEntry<bool> JackOLantern { get; private set; }
  public static ConfigEntry<bool> WelcomeMat { get; private set; }
  public static ConfigEntry<bool> Goldfish { get; private set; }
  public static ConfigEntry<bool> PlushiePajama { get; private set; }


  public static ConfigEntry<bool> Suits { get; private set; }

  public static ConfigEntry<bool> Debug { get; private set; }

  private ConfigManager(ConfigFile config)
  {

    Teleporter = config.Bind("Teleporters", "Teleporter", false, "Unlock the teleporter on new save.");
    InverseTeleporter = config.Bind("Teleporters", "Inverse Teleporter", false, "Unlock the inverse teleporter on new save.");

    LoudHorn = config.Bind("Ship upgrades", "Loud Horn", false, "Unlock the loud horn on new save.");
    SignalTranslator = config.Bind("Ship upgrades", "Signal Translator", false, "Unlock the signal translator on new save.");

    Flashlights = config.Bind("Flashlights", "Flashlight", 0, "How many flashlights to unlock on new save.");
    ProFlashlights = config.Bind("Flashlights", "Pro-flashlight", 0, "How many pro-flashlights to unlock on new save.");

    WalkieTalkies = config.Bind("Tools", "Walkie-Talkie", 0, "How many walkie-talkies to unlock on new save.");
    LockPickers = config.Bind("Tools", "Lockpicker", 0, "How many lockpickers to unlock on new save.");
    ExtensionLadders = config.Bind("Tools", "Extension Ladder", 0, "How many extension ladders to unlock on new save.");
    RadarBoosters = config.Bind("Tools", "Radar Booster", 0, "How many radar boosters to unlock on new save.");
    SprayPaints = config.Bind("Tools", "Spray Paint", 0, "How many spray paints to unlock on new save.");
    Jetpacks = config.Bind("Tools", "Jetpack", 0, "How many jetpacks to unlock on new save.");

    Inhalants = config.Bind("Consumables", "TZP-Inhalant", 0, "How many inhalants to unlock on new save.");

    Shovels = config.Bind("Weapons", "Shovel", 0, "How many shovels to unlock on new save.");
    StunGrenades = config.Bind("Weapons", "Stun Grenade", 0, "How many stun grenades to unlock on new save.");
    ZapGuns = config.Bind("Weapons", "Zap Gun", 0, "How many zap guns to unlock on new save.");
    Shotgun = config.Bind("Weapons", "Shotgun", 0, "How many shotguns to unlock on new save.");
    ShotgunShells = config.Bind("Weapons", "Shotgun Shells", 0, "How many shotgun shells to unlock on new save.");

    CozyLights = config.Bind("Decorations", "Cozy Lights", false, "Unlock the cozy lights on new save.");
    Television = config.Bind("Decorations", "Television", false, "Unlock the television on new save.");
    Toilet = config.Bind("Decorations", "Toilet", false, "Unlock the toilet on new save.");
    Shower = config.Bind("Decorations", "Shower", false, "Unlock the shower on new save.");
    RecordPlayer = config.Bind("Decorations", "Record Player", false, "Unlock the record player on new save.");
    Table = config.Bind("Decorations", "Table", false, "Unlock the table on new save.");
    RomanticTable = config.Bind("Decorations", "Romantic Table", false, "Unlock the romantic table on new save.");
    JackOLantern = config.Bind("Decorations", "Jack-O-Lantern", false, "Unlock the jack-o-lantern on new save.");
    WelcomeMat = config.Bind("Decorations", "Welcome Mat", false, "Unlock the welcome mat on new save.");
    Goldfish = config.Bind("Decorations", "Goldfish", false, "Unlock the goldfish on new save.");
    PlushiePajama = config.Bind("Decorations", "Plushie Pajama", false, "Unlock the plushie pajama on new save.");


    Suits = config.Bind("Suits", "Suits", false, "Unlock all suits on new save.");

    Debug = config.Bind("Debug", "Debugging", true, "Enable debug logging.");
  }
}