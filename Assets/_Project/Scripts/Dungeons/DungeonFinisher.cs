using System.Collections;
using System.Collections.Generic;
using Descending.Scene_Underground;
using DunGen;
using DunGen.Adapters;
using UnityEngine;

namespace Descending.Dungeons
{
    public class DungeonFinisher : BaseAdapter
    {
        [SerializeField] private UndergroundManager _undergroundManager = null;

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
            yield return new WaitForSeconds(0.2f);
        
            //Debug.Log("Astar.active.Scan()");
            AstarPath.active.Scan();
        }
    }
}
