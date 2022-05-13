using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using Descending.World;
using UnityEngine;

namespace Descending.Party
{
    public class PerceptionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Encounter"))
            {
                Encounter encounter = other.gameObject.GetComponent<Encounter>();
                if (encounter.IsActive == false)
                {
                    encounter.SetActive(true);
                }
            }
            // else if (other.CompareTag("Treasure"))
            // {
            //     Treasure treasure = other.gameObject.GetComponent<Treasure>();
            //     if (treasure.IsActive == false)
            //     {
            //         treasure.SetActive(true);
            //     }
            // }
        }

        // private void OnTriggerExit(Collider other)
        // {
        //     if (other.CompareTag("Encounter"))
        //     {
        //         Encounter encounter = other.gameObject.GetComponent<Encounter>();
        //         if (encounter.IsActive == true)
        //         {
        //             encounter.SetActive(false);
        //         }
        //     }
        //     else if (other.CompareTag("Treasure"))
        //     {
        //         Treasure treasure = other.gameObject.GetComponent<Treasure>();
        //         if (treasure.IsActive == true)
        //         {
        //             treasure.SetActive(false);
        //         }
        //     }
        // }
    }
}
