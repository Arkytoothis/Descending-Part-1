using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Transform _interactionTransform = null;

        public Transform InteractionTransform => _interactionTransform;
    }
}