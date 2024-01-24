using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
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

        checkInDictionary(Unlockables.ShipUpgradesDictionary, unlockableID, unlockableName);
        checkInDictionary(Unlockables.SuitDictionary, unlockableID, unlockableName);
        checkInDictionary(Unlockables.DecorationDictionary, unlockableID, unlockableName);
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

        // Plugin.logger.LogDebug($"Item ID: {itemID} / Item name: {itemName}");

        if (Unlockables.ItemsDictionary.ContainsKey(itemName))
        {

          if (Unlockables.ItemsDictionary[itemName] == 0)
          {
            continue;
          }

          Plugin.logger.LogInfo($"Unlocking {itemName} * {Unlockables.ItemsDictionary[itemName]}.");

          for (int i = 0; i < Unlockables.ItemsDictionary[itemName]; i++)
          {
            SpawnItem(StartOfRound.Instance, item);
          }

            try
            {
              Plugin.logger.LogDebug($"Spawning {itemName} at {spawnPosition}.");
              itemToSpawn.NetworkObject.Spawn();

            }
            catch (Exception ex)
            {
              Plugin.logger.LogError($"Could not spawn {itemName}: {ex}");
            }
          }

        }
        else
        {
          if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable |{itemName}| not found in config.");
        }


      }
    }

    private static void checkInDictionary(Dictionary<string, bool> dictionary, int unlockableID, string itemName)
    {
      if (dictionary.ContainsKey(itemName))
      {

        if (dictionary[itemName] == false) return;

        Plugin.logger.LogInfo($"Unlocking {itemName}.");
        unlockShipItem(StartOfRound.Instance, unlockableID, itemName);
      }

    }


    private static void unlockShipItem(StartOfRound instance, int unlockableID, string name)
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