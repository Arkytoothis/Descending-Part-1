using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Descending.Characters
{
    public class HeroPathfinder : MonoBehaviour
    {
        [SerializeField] private AIPath _ai = null;
        [SerializeField] private AIDestinationSetter _destinationSetter = null;

        public void SetAiActive(bool active)
        {
            //_ai.enabled = active;
            _ai.canMove = active;
            _ai.canSearch = active;
        }

        public void SetTarget(Transform target)
        {
            _destinationSetter.target = target;
        }

        public void TeleportTo(Vector3 position)
        {
            _ai.Teleport(position);
        }
    }
}
