using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public class TreasureManager : MonoBehaviour
    {
        [SerializeField] private Transform _treasuresParent = null;
        [SerializeField] private List<Treasure> _treasures = new List<Treasure>();

        public void Setup(Vector3 startPosition, float threatModifier)
        {
            for (int i = 0; i < _treasures.Count; i++)
            {
                float distance = Vector3.Distance(startPosition, _treasures[i].transform.position);
                _treasures[i].GenerateTreasure((int)(distance / threatModifier));
            }
        }

        public void RegisterTreasure(Treasure treasure)
        {
            _treasures.Add(treasure);

            if (treasure.SetParent == true)
            {
                treasure.transform.SetParent(_treasuresParent);
            }
        }

        public void InteractWithTreasure(Treasure treasure)
        {
            //Debug.Log("Interacting with treasure");
        }

        public void OnRemoveTreasure(Treasure treasure)
        {
            StartCoroutine(CleanListWithDelay());
        }

        private IEnumerator CleanListWithDelay()
        {
            yield return new WaitForEndOfFrame();
            
            for (int i = 0; i < _treasures.Count; i++)
            {
                if (_treasures[i] == null || _treasures[i].gameObject == null || _treasures[i].name == "None (Treasure)")
                {
                    _treasures.RemoveAt(i);
                }
            }
        }
    }
}
