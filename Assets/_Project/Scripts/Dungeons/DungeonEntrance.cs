using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
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
                SceneManager.LoadScene((int) GameScenes.Underground);
            }
        }
    }
}
