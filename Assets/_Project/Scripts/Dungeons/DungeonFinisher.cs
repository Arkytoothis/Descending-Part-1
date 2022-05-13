using System.Collections;
using System.Collections.Generic;
//using Descending.Scene_Underground;
using DunGen;
using DunGen.Adapters;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Dungeons
{
    public class DungeonFinisher : BaseAdapter
    {
        //[SerializeField] private UndergroundManager _undergroundManager = null;

        private Vector3 _startPosition;
        protected override void Run(DungeonGenerator generator)
        {
            //_undergroundManager.GenerateEncounters();
            //_undergroundManager.GenerateTreasures();
            //_undergroundManager.SetupParty();
            StartCoroutine(AstarScan());
        }

        private IEnumerator AstarScan()
        {
            yield return new WaitForEndOfFrame();
        
            //Debug.Log("Astar.active.Scan()");
            AstarPath.active.Scan();
        }
    }
}
