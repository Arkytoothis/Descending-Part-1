using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class FeatureSpawner : MonoBehaviour
    {
        [SerializeField] private FeatureSpawnParametersEvent onRegisterSpawner = null;
        
        private GameObject _featureClone = null;

        private void Start()
        {
            onRegisterSpawner.Invoke(new FeatureSpawnParameters(this));
        }

        public Feature Spawn(string featureKey, Transform parent)
        {
            _featureClone = Instantiate(Database.instance.Features.GetFeature(featureKey).Prefab, parent);
            _featureClone.transform.position = transform.position;
            Destroy(gameObject);

            return _featureClone.GetComponent<Feature>();
        }
    }
}
