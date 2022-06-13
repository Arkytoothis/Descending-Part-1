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
        
        [SerializeField] private BoolEvent onSetPartyMovementEnabled = null;
        [SerializeField] private CombatParametersEvent onStartCombat = null;

        private Encounter _currentEncounter = null;
        private List<Encounter> _encounters = new List<Encounter>();
        
        public void OnRegisterEncounter(Encounter encounter)
        {
            //Debug.Log("Registering Encounter");
            EncounterGenerator.BuildEncounter(encounter);
            encounter.transform.SetParent(_encountersParent, true);
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

        public void OnEncounterTriggered(Encounter encounter)
        {
            _currentEncounter = encounter;
            _currentEncounter.Setup(_partyManager);
            onSetPartyMovementEnabled.Invoke(false);
            onStartCombat.Invoke(new CombatParameters(_partyManager, encounter));
        }
    }
}
