using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public class Dungeon : Feature
    {
        //[SerializeField] private string _dungeonType = "";
        //[SerializeField] private int _levels = 0;
        //[SerializeField] private int _roomsPerLevel = 0;

        public override void Interact()
        {
            Debug.Log("Interacting with " + Definition.Name);
        }
    }
}
