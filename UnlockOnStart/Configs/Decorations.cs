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
    CozyLights = config.Bind("Decorations", "Cozy Lights", false, "Unlock the cozy lights on new save.");
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

    Suits = config.Bind("Suits", "Suits", false, "Unlock all suits on new save.");
  }

}
