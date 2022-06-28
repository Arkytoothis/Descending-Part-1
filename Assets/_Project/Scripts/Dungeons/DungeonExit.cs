using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Core;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Dungeons
{
    public class DungeonExit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Loading Overworld");
                SaveData();
                SceneManager.LoadScene((int) GameScenes.Overworld);
            }
        }

        private void SaveData()
        {
            byte[] bytes = null;
            SceneLoadData loadDate = new SceneLoadData(SceneTransitionTypes.Underworld_Overworld, SceneBuildTypes.Load);
            bytes = SerializationUtility.SerializeValue(loadDate, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.SceneLoadFilePath, bytes);
        }
    }
}
