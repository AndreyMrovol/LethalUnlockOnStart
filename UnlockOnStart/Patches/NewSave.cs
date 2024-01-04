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
    [HarmonyPrefix]
    internal static void LoadUnlockablesFromConfig()
    {
      // check if the player is a host, if not return
      if (!GameNetworkManager.Instance.isHostingGame) return;

      List<UnlockableItem> unlockablesList = StartOfRound.Instance.unlockablesList.unlockables;

      foreach (UnlockableItem unlockable in unlockablesList)
      {
        var unlockableName = unlockable.unlockableName;
        var unlockableID = unlockablesList.IndexOf(unlockable);

        // Plugin.logger.LogDebug($"Unlockable ID: {unlockableID}");
        // Plugin.logger.LogDebug($"Unlockable name: {unlockableName}");

        if (Unlockables.ShipUpgradesDictionary.ContainsKey(unlockableName))
        {

          if (Unlockables.ShipUpgradesDictionary[unlockableName] == false)
          {
            continue;
          }

          Unlockables.ShipUpgradesDictionary.TryGetValue(unlockableName, out bool value);
          Plugin.logger.LogInfo($"Unlocking {unlockableName}.");

          unlockShipItem(StartOfRound.Instance, unlockableID, unlockableName);

        }
        else if (Unlockables.SuitDictionary.ContainsKey(unlockableName))
        {
          if (Unlockables.SuitDictionary[unlockableName] == false)
          {
            continue;
          }

          Unlockables.SuitDictionary.TryGetValue(unlockableName, out bool value);
          Plugin.logger.LogInfo($"Unlocking {unlockableName}.");

          unlockShipItem(StartOfRound.Instance, unlockableID, unlockableName);

        }
        else
        {
          if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable {unlockableName} not found in config.");
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

        // Plugin.logger.LogDebug($"Item ID: {itemID} / Item name: {itemName}");

        if (Unlockables.ItemsDictionary.ContainsKey(itemName))
        {

          if (Unlockables.ItemsDictionary[itemName] == 0)
          {
            continue;
          }

          Plugin.logger.LogInfo($"Unlocking {itemName}.");

          for (int i = 0; i < Unlockables.ItemsDictionary[itemName]; i++)
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
          if (ConfigManager.Debug.Value) Plugin.logger.LogDebug($"Unlockable {itemName} not found in config.");
        }


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



  }




}