using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending
{
    [System.Serializable]
    public class EnemyShort
    {
        [SerializeField] private string _key = "";
        [SerializeField] private int _level = 0;

        public string Key => _key;
        public int Level => _level;

        public EnemyShort(string key, int level)
        {
            _key = key;
            _level = level;
        }
    }
}
