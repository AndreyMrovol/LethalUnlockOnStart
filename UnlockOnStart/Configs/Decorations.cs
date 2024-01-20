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

  public static ConfigEntry<bool> Suits { get; private set; }

  private DecorationsConfigManager(ConfigFile config)
  {
    CozyLights = config.Bind("Cozy Lights", "Cozy Lights", false, "Unlock the cozy lights on new save.");
    Television = config.Bind("Television", "Television", false, "Unlock the television on new save.");
    Toilet = config.Bind("Toilet", "Toilet", false, "Unlock the toilet on new save.");
    Shower = config.Bind("Shower", "Shower", false, "Unlock the shower on new save.");
    RecordPlayer = config.Bind("Record Player", "Record Player", false, "Unlock the record player on new save.");
    Table = config.Bind("Table", "Table", false, "Unlock the table on new save.");
    RomanticTable = config.Bind("Romantic Table", "Romantic Table", false, "Unlock the romantic table on new save.");
    JackOLantern = config.Bind("Jack-O-Lantern", "Jack-O-Lantern", false, "Unlock the jack-o-lantern on new save.");
    WelcomeMat = config.Bind("Welcome Mat", "Welcome Mat", false, "Unlock the welcome mat on new save.");
    Goldfish = config.Bind("Goldfish", "Goldfish", false, "Unlock the goldfish on new save.");
    PlushiePajama = config.Bind("Plushie Pajama", "Plushie Pajama", false, "Unlock the plushie pajama on new save.");

    Suits = config.Bind("Suits", "Suits", false, "Unlock all suits on new save.");
  }

}
