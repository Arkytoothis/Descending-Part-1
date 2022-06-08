using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class PartySpawner : MonoBehaviour
    {
        public void SpawnParty(GameObject partyObject)
        {
            partyObject.transform.position = transform.position;
        }
    }
}