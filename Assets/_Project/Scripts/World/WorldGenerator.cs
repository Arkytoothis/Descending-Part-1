using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using UnityEngine;

namespace Descending.World
{
    public class WorldGenerator : MonoBehaviour
    {
        //[SerializeField] private Graph _graph = null;
        [SerializeField] private int _seed = 12345;
        [SerializeField] private bool _randomizeSeed = false;
        [SerializeField] private PartyController _party = null;
        [SerializeField] private FeatureManager _featureManager = null;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _threatModifier = 100f;

        public Vector3 StartPosition => _startPosition;
        public float ThreatModifier => _threatModifier;

        public void Generate()
        {
            //RandomizeMap();
            _featureManager.Setup(_party, ref _startPosition, _threatModifier);
            //StartCoroutine(ScanAstar());
            
            _party.Select();
        }

        public void RandomizeMap()
        {
            if (_randomizeSeed == true)
            {
                Debug.Log("Randomizing");
                _seed = UnityEngine.Random.Range(1, 99999);
            }

            //_graph.random = new Noise(_seed, permutationCount: 32768);
        }

        private IEnumerator ScanAstar()
        {
            yield return new WaitForSeconds(1f);
            
            AstarPath.active.Scan();
        }

        public void SetStartPosition(Vector3 startPosition)
        {
            _startPosition = startPosition;
        }
    }
}
