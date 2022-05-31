using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using UnityEngine;

namespace Descending.Combat
{
    public class HeroCollider : CombatCollider
    {
        private Hero _hero = null;

        private void Awake()
        {
            _hero = GetComponentInParent<Hero>();
        }

        private void OnMouseEnter()
        {
            if (_hero.CurrentTile != null)
            {
                _hero.CurrentTile.Highlight();
            }
        }

        private void OnMouseExit()
        {
            if (_hero.CurrentTile != null)
            {
                _hero.CurrentTile.Unhighlight();
            }
        }
    }
}