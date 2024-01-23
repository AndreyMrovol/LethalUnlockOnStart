using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
namespace UnlockOnStart;

public class ItemsConfigManager
{

  public static ItemsConfigManager Instance { get; private set; }

  public static void Init(ConfigFile config)
  {
    Instance = new ItemsConfigManager(config);
  }

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


  private ItemsConfigManager(ConfigFile config)
  {
    ExtensionLadders = config.Bind("Items", "Extension Ladder", 0, "How many extension ladders to unlock on new save.");
    Flashlights = config.Bind("Items", "Flashlight", 0, "How many flashlights to unlock on new save.");
    Inhalants = config.Bind("Items", "TZP-Inhalant", 0, "How many inhalants to unlock on new save.");
    Jetpacks = config.Bind("Items", "Jetpack", 0, "How many jetpacks to unlock on new save.");
    LockPickers = config.Bind("Items", "Lockpicker", 0, "How many lockpickers to unlock on new save.");
    ProFlashlights = config.Bind("Items", "Pro-flashlight", 0, "How many pro-flashlights to unlock on new save.");
    RadarBoosters = config.Bind("Items", "Radar Booster", 0, "How many radar boosters to unlock on new save.");
    Shotgun = config.Bind("Items", "Shotgun", 0, "How many shotguns to unlock on new save.");
    ShotgunShells = config.Bind("Items", "Shotgun Shells", 0, "How many shotgun shells to unlock on new save.");
    Shovels = config.Bind("Items", "Shovel", 0, "How many shovels to unlock on new save.");
    SprayPaints = config.Bind("Items", "Spray Paint", 0, "How many spray paints to unlock on new save.");
    StunGrenades = config.Bind("Items", "Stun Grenade", 0, "How many stun grenades to unlock on new save.");
    WalkieTalkies = config.Bind("Items", "Walkie-Talkie", 0, "How many walkie-talkies to unlock on new save.");
    ZapGuns = config.Bind("Items", "Zap Gun", 0, "How many zap guns to unlock on new save.");
  }

}