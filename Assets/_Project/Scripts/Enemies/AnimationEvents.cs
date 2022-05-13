using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

namespace Descending.Enemies
{
    public class AnimationEvents : MonoBehaviour
    {

        public void Setup()
        {
        }

        public void Shoot()
        {
        }

        public void FootR()
        {
            string sound = "footstep_grass_walk_" + Random.Range(1, 11);
            //MasterAudio.PlaySound3DAtTransform(sound, transform, .1f, 1f);
        }

        public void FootL()
        {
            string sound = "footstep_grass_walk_" + Random.Range(1, 11);
            //MasterAudio.PlaySound3DAtTransform(sound, transform, .1f, 1f);
        }

        public void Land()
        {
        }

        public void WeaponSwitch()
        {
        }

        public void Hit()
        {
        }

        public void Strike()
        {
        }
    }
}