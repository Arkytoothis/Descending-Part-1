using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Dungeons
{
    public class DungeonExit : MonoBehaviour
    {
        [SerializeField] private DungeonEvent onTriggerDungeonExitWindow = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hero") == true)
            {
                //Debug.Log("Collision: " + other.name);
                onTriggerDungeonExitWindow.Invoke(null);
            }
        }
    }
}
