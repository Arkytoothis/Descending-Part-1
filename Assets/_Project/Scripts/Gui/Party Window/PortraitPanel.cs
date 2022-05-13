using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui.Party_Window
{
    public class PortraitPanel : MonoBehaviour
    {
        [SerializeField] private RawImage _portrait = null;

        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            hero.Portrait.RefreshFarCam();
            _portrait.texture = hero.Portrait.GetFarRt();
        }
    }
}