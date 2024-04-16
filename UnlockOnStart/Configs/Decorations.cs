using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace UnlockOnStart;

public class DecorationsConfigManager
{

  public static DecorationsConfigManager Instance { get; private set; }

  public static void Init(ConfigFile config)
  {
    Instance = new DecorationsConfigManager(config);
  }

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
  public static ConfigEntry<bool> DiscoBall { get; private set; }

  public static ConfigEntry<bool> HazardSuit { get; private set; }
  public static ConfigEntry<bool> GreenSuit { get; private set; }
  public static ConfigEntry<bool> PajamaSuit { get; private set; }
  public static ConfigEntry<bool> PurpleSuit { get; private set; }
public static ConfigEntry<bool> BeeSuit { get; private set; }
public static ConfigEntry<bool> BunnySuit { get; private set; }

  private DecorationsConfigManager(ConfigFile config)
  {
    CozyLights = config.Bind("Decorations", "Cozy Lights", false, "Unlock the cozy lights on new save.");
    DiscoBall = config.Bind("Decorations", "Disco Ball", false, "Unlock the disco ball on new save.");
    Goldfish = config.Bind("Decorations", "Goldfish", false, "Unlock the goldfish on new save.");
    JackOLantern = config.Bind("Decorations", "Jack-O-Lantern", false, "Unlock the jack-o-lantern on new save.");
    PlushiePajama = config.Bind("Decorations", "Plushie Pajama", false, "Unlock the plushie pajama on new save.");
    RecordPlayer = config.Bind("Decorations", "Record Player", false, "Unlock the record player on new save.");
    RomanticTable = config.Bind("Decorations", "Romantic Table", false, "Unlock the romantic table on new save.");
    Shower = config.Bind("Decorations", "Shower", false, "Unlock the shower on new save.");
    Table = config.Bind("Decorations", "Table", false, "Unlock the table on new save.");
    Television = config.Bind("Decorations", "Television", false, "Unlock the television on new save.");
    Toilet = config.Bind("Decorations", "Toilet", false, "Unlock the toilet on new save.");
    WelcomeMat = config.Bind("Decorations", "Welcome Mat", false, "Unlock the welcome mat on new save.");

    HazardSuit = config.Bind("Suits", "Hazard Suit", false, "Unlock the hazmat suit on new save.");
    GreenSuit = config.Bind("Suits", "Green Suit", false, "Unlock the green suit on new save.");
    PajamaSuit = config.Bind("Suits", "Pajama Suit", false, "Unlock the pajama suit on new save.");
    PurpleSuit = config.Bind("Suits", "Purple Suit", false, "Unlock the purple suit on new save.");
    BeeSuit = config.Bind("Suits", "Bee Suit", false, "Unlock the bee suit on new save.");
    BunnySuit = config.Bind("Suits", "Bunny Suit", false, "Unlock the bunny suit on new save.");
  }

}
