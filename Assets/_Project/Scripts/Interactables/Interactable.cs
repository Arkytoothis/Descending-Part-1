using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Interactables
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public abstract void Interact();
    }
}