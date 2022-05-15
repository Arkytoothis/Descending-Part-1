using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Descending.Characters
{
    public class HeroPathfinder : MonoBehaviour
    {
        [SerializeField] private RichAI _ai = null;

        public void SetAiActive(bool active)
        {
            _ai.enabled = active;
        }
        
        public void SetDestination(Vector3 destination)
        {
            _ai.destination = destination;
        }
        
        public void EnablePathing()
        {
            _ai.canMove = true;
            _ai.canSearch = true;
        }

        public void DisablePathing()
        {
            _ai.canMove = false;
            _ai.canSearch = false;
        }

        public void TeleportTo(Vector3 position)
        {
            _ai.Teleport(position);
        }
    }
}
