using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        [SerializeField] private Transform _encountersParent = null;
        [SerializeField] private PartyManager _partyManager = null;
        [SerializeField] private List<Transform> _formationPositions = null;
        
        [SerializeField] private BoolEvent onSetPartyMovementEnabled = null;
        [SerializeField] private CombatParametersEvent onStartCombat = null;

        private Encounter _currentEncounter = null;
        private List<Encounter> _encounters = new List<Encounter>();

        public void Setup()
        {
        }
        
        public void OnRegisterEncounter(Encounter encounter)
        {
            //Debug.Log("Registering Encounter");
            encounter.transform.SetParent(_encountersParent, true);
            EncounterGenerator.BuildEncounter(encounter);
            _encounters.Add(encounter);
        }

        public void OnCombatEnded(bool b)
        {
            Destroy(_currentEncounter.gameObject);
            
            for (int i = 0; i < _encounters.Count; i++)
            {
                if (_encounters[i] == null)
                {
                    _encounters.RemoveAt(i);
                }
            }
            
            _currentEncounter = null;
            onSetPartyMovementEnabled.Invoke(true);
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

        public void CalculateTreatLevels(Vector3 startPosition, float threatModifier)
        {
            for (int i = 0; i < _encounters.Count; i++)
            {
                int threatLevel = (int)(Vector3.Distance(_encounters[i].transform.position, startPosition) / threatModifier); 
                _encounters[i].Setup(_partyManager, threatLevel);
            }
        }
        
        public void OnEncounterTriggered(Encounter encounter)
        {
            _currentEncounter = encounter;

            for (int i = 0; i < _currentEncounter.Enemies.Count; i++)
            {
                _currentEncounter.Enemies[i].transform.position = _formationPositions[i].position;
            }
            
            onSetPartyMovementEnabled.Invoke(false);
            onStartCombat.Invoke(new CombatParameters(_partyManager, encounter));
        }

        public void OnHighlightEnemy_World(int index)
        {
            for (int i = 0; i < _currentEncounter.Enemies.Count; i++)
            {
                _currentEncounter.Enemies[i].Unhighlight();
            } 
            if (index > -1)
            {
                _currentEncounter.Enemies[index].Highlight();
            }
        }
    }
}
