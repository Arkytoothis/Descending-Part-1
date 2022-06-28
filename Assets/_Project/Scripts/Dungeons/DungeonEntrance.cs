using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Core;
using Descending.World;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Dungeons
{
    public class DungeonEntrance : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Loading Dungeon");
                SaveSpawnPosition(other.transform.position);
                SceneManager.LoadScene((int) GameScenes.Underground);
            }
        }

        private void SaveSpawnPosition(Vector3 partyPosition)
        {
            byte[] bytes = null;
            SceneLoadData loadDate = new SceneLoadData(SceneTransitionTypes.Overworld_Underworld, SceneBuildTypes.Load);
            bytes = SerializationUtility.SerializeValue(loadDate, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.SceneLoadFilePath, bytes);

            PartySpawnData spawnData = new PartySpawnData(partyPosition);
            bytes = SerializationUtility.SerializeValue(spawnData, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.PartySpawnFilePath, bytes);
        }
    }
}
