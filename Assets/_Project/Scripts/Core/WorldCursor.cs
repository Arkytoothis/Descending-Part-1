using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Core
{
    public class WorldCursor : MonoBehaviour
    {
        private void Start()
        {
            //TerrainGridSystem.instance.OnCellEnter += CellEntered;
        }

        // private void CellEntered(TerrainGridSystem tgs, int index)
        // {
        //     int x = tgs.cells[index].column;
        //     int y = tgs.cells[index].row;
        //     
        //     //Debug.Log("X: " + x + " Y: " + y);
        // }
    }
}
