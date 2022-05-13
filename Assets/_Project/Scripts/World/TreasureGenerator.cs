using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.World
{
    public class TreasureGenerator : MonoBehaviour
    {
        //[SerializeField] private GameObject _treasurePrefab = null;
        [SerializeField] private Transform _treasureParent = null;

        private List<Treasure> _treasure = new List<Treasure>();
        
        public void GenerateTreasure()
        {
            _treasureParent.ClearTransform();
            _treasure.Clear();
            
            // for (int threatLevel = 1; threatLevel <= 10; threatLevel++)
            // {
            //     for (int j = 0; j < _treasurePreThreatLevel; j++)
            //     {
            //         GameObject clone = Instantiate(_treasurePrefab, _treasureParent);
            //         Treasure treasure = clone.GetComponent<Treasure>();
            //         int rndIndex = Random.Range(0, tiles[threatLevel].Count);
            //         treasure.GenerateTreasure(threatLevel, tiles[threatLevel][rndIndex]);
            //         _treasure.Add(treasure);
            //         
            //         tiles[threatLevel][rndIndex].AddTreasure(treasure);
            //         tiles[threatLevel].RemoveAt(rndIndex);
            //     }
            // }
        }
    }
}
