using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Interactables
{
    public class Door : Interactable
    {
        public override void Interact()
        {
            Debug.Log("Interacting with Door");
        }
    }
}