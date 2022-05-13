using System;
using System.Collections;
using System.Collections.Generic;
using Descending.World;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class FeatureDetector : MonoBehaviour
    {
        //[SerializeField] private PartyController _party = null;

        [SerializeField] private FeatureEvent onFeatureEntered = null;
        [SerializeField] private FeatureEvent onFeatureExited = null;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Feature"))
            {
                Feature feature = other.GetComponent<Feature>();
                //_party.FeatureEntered(feature);
                onFeatureEntered.Invoke(feature);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Feature"))
            {
                Feature feature = other.GetComponent<Feature>();
                //_party.FeatureExited(feature);
                onFeatureExited.Invoke(feature);
            }
        }
    }
}
