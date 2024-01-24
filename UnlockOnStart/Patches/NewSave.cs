using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UnlockOnStart
{

  [HarmonyPatch(typeof(StartOfRound))]
  internal class NewSaveStartPatch
  {
    [HarmonyPatch("firstDayAnimation")]
    [HarmonyPostfix]
    internal static void LoadUnlockablesFromConfig()
    {

      if (StartOfRound.Instance.gameStats.daysSpent == 0 && !StartOfRound.Instance.isChallengeFile)
      {
        Plugin.logger.LogInfo("New save detected, loading unlockables from config.");
      }
      else
      {
        Plugin.logger.LogInfo("Not a new save, not loading unlockables from config.");
        return;
      }

      TimeOfDay.Instance.quotaVariables.startingCredits = ConfigManager.Money.Value;

      // check if the player is a host, if not return
      if (!GameNetworkManager.Instance.isHostingGame) return;

      List<UnlockableItem> unlockablesList = StartOfRound.Instance.unlockablesList.unlockables;

      foreach (UnlockableItem unlockable in unlockablesList)
      {
        var unlockableName = unlockable.unlockableName;
        var unlockableID = unlockablesList.IndexOf(unlockable);

        if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable ID: {unlockableID} / Unlockable name: {unlockableName}");

        var shipUpgradeResult = CheckInDictionary(Unlockables.ShipUpgradesDictionary, unlockableID, unlockableName);
        var suitResult = CheckInDictionary(Unlockables.SuitDictionary, unlockableID, unlockableName);
        var DecorationResult = CheckInDictionary(Unlockables.DecorationDictionary, unlockableID, unlockableName);

        if (shipUpgradeResult || suitResult || DecorationResult) continue;

        if (!shipUpgradeResult && !suitResult && !DecorationResult)
        {
          if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable |{unlockableName}| not found in config.");

          if (Unlockables.ItemsToIgnore.Contains(unlockableName)) continue;

          bool toUnlock = ConfigManager.configFile.Bind("Modded", unlockableName, false, $"Unlock {unlockableName} on new save.").Value;
          if (toUnlock) UnlockShipItem(StartOfRound.Instance, unlockableID, unlockableName);
        }
      }

      SpawnItemsFromConfig();
    }


    internal static void SpawnItemsFromConfig()
    {

      List<Item> allItemsList = StartOfRound.Instance.allItemsList.itemsList;

      foreach (Item item in allItemsList)
      {
        var itemName = item.itemName;
        var itemID = allItemsList.IndexOf(item);

        if (item.isScrap) continue;
        if (Unlockables.ItemsToIgnore.Contains(itemName)) continue;

        Plugin.logger.LogDebug($"Item ID: {itemID} / Item name: {itemName}");
        Plugin.logger.LogDebug($"Is scrap: {item.isScrap} / Is conductive: {item.isConductiveMetal}");

        if (Unlockables.ItemsDictionary.ContainsKey(itemName))
        {

          if (Unlockables.ItemsDictionary[itemName] == 0) continue;

          Plugin.logger.LogInfo($"Unlocking {itemName} * {Unlockables.ItemsDictionary[itemName]}.");

          for (int i = 0; i < Unlockables.ItemsDictionary[itemName]; i++)
          {
            SpawnItem(StartOfRound.Instance, item);
          }

        }
        else
        {

          int howManyToUnlock = ConfigManager.configFile.Bind("Modded.Items", itemName, 0, $"How many {itemName} to unlock on new save.").Value;
          if (howManyToUnlock == 0)
          {
            continue;
          }
          else
          {
            Plugin.logger.LogInfo($"Unlocking {itemName} * {howManyToUnlock}.");
            for (int i = 0; i < howManyToUnlock; i++)
            {
              SpawnItem(StartOfRound.Instance, item);
            }
          }

          if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable |{itemName}| not found in config.");

        }


      }
    }

    private static bool CheckInDictionary(Dictionary<string, bool> dictionary, int unlockableID, string itemName)
    {
      if (dictionary.ContainsKey(itemName))
      {
        if (dictionary[itemName] == false) return true;

        Plugin.logger.LogInfo($"Unlocking {itemName}.");
        UnlockShipItem(StartOfRound.Instance, unlockableID, itemName);
        return true;
      }

      return false;
    }


    private static void UnlockShipItem(StartOfRound instance, int unlockableID, string name)
    {
      try
      {
        if (ConfigManager.Debug.Value) Plugin.logger.LogInfo($"Attempting to unlock {name}");
        var unlockShipMethod = instance.GetType().GetMethod("UnlockShipObject",
            BindingFlags.NonPublic | BindingFlags.Instance);
        unlockShipMethod.Invoke(instance, new object[] { unlockableID });
        // Plugin.logger.LogInfo($"Spawning {name}");
      }
      catch (NullReferenceException ex)
      {
        Plugin.logger.LogError($"Could not invoke UnlockShipObject method: {ex}");
      }
    }

    private static void SpawnItem(StartOfRound instance, Item item)
    {

      Vector3 spawnPosition = StartOfRound.Instance.playerSpawnPositions[1].position;
      spawnPosition.x += UnityEngine.Random.Range(-0.7f, 0.7f);
      spawnPosition.z += UnityEngine.Random.Range(2f, 2f);
      spawnPosition.y += 0.5f;

      GrabbableObject itemToSpawn = UnityEngine.Object.Instantiate<GameObject>(item.spawnPrefab, spawnPosition, Quaternion.identity, StartOfRound.Instance.elevatorTransform).GetComponent<GrabbableObject>();
      itemToSpawn.fallTime = 1f;
      itemToSpawn.hasHitGround = false;
      itemToSpawn.scrapPersistedThroughRounds = true;
      itemToSpawn.isInElevator = true;
      itemToSpawn.isInShipRoom = true;

      if (item.itemName == "Shotgun")
      {
        // assert itemToSpawn to be ShotgunItem
        ShotgunItem shotgunItem = itemToSpawn as ShotgunItem;

        shotgunItem.shellsLoaded = 0;
        shotgunItem.safetyOn = true;

        itemToSpawn = shotgunItem;
      }

      try
      {
        Plugin.logger.LogDebug($"Spawning {item.itemName} at {spawnPosition}.");
        itemToSpawn.NetworkObject.Spawn();

      }
      catch (Exception ex)
      {
        Plugin.logger.LogError($"Could not spawn {item.itemName}: {ex}");
      }


    }



  }




}