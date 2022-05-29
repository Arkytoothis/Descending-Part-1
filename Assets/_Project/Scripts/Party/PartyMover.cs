using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using UnityEngine;

namespace Descending
{
    public class PartyMover : MonoBehaviour
    {
        [SerializeField] private PartyController _partyController = null;
        [SerializeField] private PartyFormation _formation = null;
        
        public void ResetFormation()
        {
            for (int i = 0; i < _partyController.PartyData.Heroes.Count; i++)
            {
                _partyController.PartyData.Heroes[i].transform.position = _formation.Positions[i].position;
            }
        }

        public void SetPathingTargets()
        {
            for (int i = 0; i < _partyController.PartyData.Heroes.Count; i++)
            {
                _partyController.PartyData.Heroes[i].Pathfinder.SetTarget(_formation.Positions[i]);
            }    
        }
        
        public void SetPosition(Vector3 position)
        {
            ResetFormation();
        }
        
        public void MoveTo(Vector3 position)
        {
            SetPathingTargets();
        }
    }
}
