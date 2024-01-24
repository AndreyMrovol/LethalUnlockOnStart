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

  public static ConfigEntry<bool> Debug { get; private set; }
  public static ConfigEntry<int> Money { get; private set; }

  public static ConfigFile configFile { get; private set; }

  private ConfigManager(ConfigFile config)
  {
    configFile = config;

    Debug = config.Bind("General", "Debugging", true, "Enable debug logging.");


    Money = config.Bind("Money", "Money", 60, "How much money to unlock on new save.");
  }
}