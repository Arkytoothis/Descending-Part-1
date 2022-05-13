using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.World
{
    [CreateAssetMenu(fileName = "Feature Definition", menuName = "Descending/Definition/Feature Definition")]
    public class FeatureDefinition : ScriptableObject
    {
        public string Name;
        public string Key;
        public string InteractionString = "Interact";

        public GameObject Prefab;
    }
}
