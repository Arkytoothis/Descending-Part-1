using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Combat
{
    public class CombatTile : MonoBehaviour
    {
        [SerializeField] private int _x = -1;
        [SerializeField] private int _y = -1;

        public int X => _x;
        public int Y => _y;

        public void Setup(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}