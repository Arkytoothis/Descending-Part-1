using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Descending.Characters
{
    public class HeroPathfinder : MonoBehaviour
    {
        [SerializeField] private RichAI _ai = null;

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
    }
}
