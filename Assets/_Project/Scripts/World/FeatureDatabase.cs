using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Core;
using UnityEngine;

namespace Descending.World
{
    [CreateAssetMenu(fileName = "Feature Database", menuName = "Descending/Database/Feature Database")]
    public class FeatureDatabase : ScriptableObject
    {
        [SerializeField] private FeatureDefinitionDictionary _data = null;
        public FeatureDefinitionDictionary Dictionary { get => _data; }

        public FeatureDefinition GetFeature(string key)
        {
            if (Contains(key))
            {
                return _data[key];
            }
            else
            {
                Debug.Log("Feature Key: (" + key + ") does not exist");
                return null;
            }
        }

        public string GetRandomKey()
        {
            return Utilities.RandomKey(_data);
        }

        public bool Contains(string key)
        {
            return _data.ContainsKey(key);
        }
    }
}