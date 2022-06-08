using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        [SerializeField] private Transform _encountersParent = null;
        
        private List<Encounter> _encounters = new List<Encounter>();
        
        public void Setup()
        {
        }
        
        public void RegisterEncounter(Encounter encounter)
        {
            Debug.Log("Registering Encounter");
            _encounters.Add(encounter);

            if (encounter.SetParent)
            {
                encounter.transform.SetParent(_encountersParent, true);
            }
        }

        public void GenerateEncounters(Vector3 startPosition, float threatModifier)
        {
            //Debug.Log("Generating Encounters");
            for (int i = 0; i < _encounters.Count; i++)
            {
                float distance = Vector3.Distance(startPosition, _encounters[i].transform.position);
                EncounterGenerator.BuildEncounter(_encounters[i], (int)(distance / threatModifier));
                _encounters[i].SpawnEnemies();
            }
        }

        public void OnCombatEnded(bool b)
        {
            for (int i = 0; i < _encounters.Count; i++)
            {
                if (_encounters[i] == null)
                {
                    _encounters.RemoveAt(i);
                }
            }
        }

        private void Clear()
        {
            _encountersParent.ClearTransform();
            for (int i = 0; i < _encounters.Count; i++)
            {
                Destroy(_encounters[i].gameObject);
            }
            
            _encounters.Clear();
        }
    }
}
