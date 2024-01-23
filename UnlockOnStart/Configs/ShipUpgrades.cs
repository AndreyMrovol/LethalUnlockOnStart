using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace UnlockOnStart;

public class ShipUpgradesConfigManager
{

  public static ShipUpgradesConfigManager Instance { get; private set; }

  public static void Init(ConfigFile config)
  {
    Instance = new ShipUpgradesConfigManager(config);
  }

  public static ConfigEntry<bool> Teleporter { get; private set; }
  public static ConfigEntry<bool> InverseTeleporter { get; private set; }
  public static ConfigEntry<bool> LoudHorn { get; private set; }
  public static ConfigEntry<bool> SignalTranslator { get; private set; }

  private ShipUpgradesConfigManager(ConfigFile config)
  {

    Teleporter = config.Bind("Teleporter", "Teleporter", false, "Unlock the teleporter on new save.");
    InverseTeleporter = config.Bind("Inverse Teleporter", "Inverse Teleporter", false, "Unlock the inverse teleporter on new save.");

    LoudHorn = config.Bind("Ship Upgrades", "Loud Horn", false, "Unlock the loud horn on new save.");
    SignalTranslator = config.Bind("Ship Upgrades", "Signal Translator", false, "Unlock the signal translator on new save.");

  }

}