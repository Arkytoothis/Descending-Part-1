using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Descending.Characters;
using Descending.Core;
using Descending.Enemies;
using UnityEngine;

namespace Descending.Combat
{
    public enum AttackResults { Critical_Hit, Hit, Graze, Miss, Fumble, Number, None }
    
    public static class AttackCalculator
    {
        // public static AttackData ProcessAttack(Hero attacker, Enemy defender)
        // {
        //     AttackData attackData = AttackResult(attacker.Attributes.GetStatistic("Attack").Current, defender.Attributes.GetStatistic("Dodge").Current);
        //     
        //     if (attackData.Result == AttackResults.Hit)
        //     {
        //         attackData.Damage = CalcDamage(attacker, defender);
        //         Utilities.PlayParticleSystem(defender.EnemyDefinition.HitEffect, defender.HitEffectTransform.position);
        //
        //         if (Random.Range(0, 100) < 50)
        //         {
        //             string sound = defender.EnemyDefinition.GetWoundSound();
        //             MasterAudio.PlaySound3DAtTransform(sound, defender.transform, .3f, 1f);
        //         }
        //         //Debug.Log(attacker.GetName() + " hits " + defender.GetName() + " for " + attackData.Damage + " damage");
        //     }
        //     
        //     return attackData;
        // }
        //
        // public static AttackData ProcessAttack(Enemy attacker, Hero defender)
        // {
        //     AttackData attackData = AttackResult(attacker.Attributes.GetStatistic("Attack").Current, defender.Attributes.GetStatistic("Dodge").Current);
        //     
        //     if (attackData.Result == AttackResults.Hit)
        //     {
        //         attackData.Damage = CalcDamage(attacker, defender);
        //         Utilities.PlayParticleSystem(defender.HeroData.RaceDefinition.HitEffect, defender.HitEffectTransform.position);
        //
        //         if (Random.Range(0, 100) < 50)
        //         {
        //             string sound = defender.HeroData.RaceDefinition.GetWoundSound(defender.HeroData.Gender);
        //             MasterAudio.PlaySound3DAtTransform(sound, defender.transform, .3f, 1f);
        //         }
        //         
        //         //Debug.Log(attacker.GetName() + " hits " + defender.GetName() + " for " + attackData.Damage + " damage");
        //     }
        //     
        //     return attackData;
        // }
        //
        // private static AttackData AttackResult(int attack, int defense)
        // {
        //     AttackData attackData = new AttackData();
        //     int attackRoll = Random.Range(0, 100) + attack;
        //     int defenseRoll = Random.Range(0, 100) + defense;
        //
        //     attackData.AttackRoll = attackRoll;
        //     attackData.DefenseRoll = defenseRoll;
        //     
        //     if (attackRoll > defenseRoll)
        //     {
        //         attackData.Result = AttackResults.Hit;
        //     }
        //     else
        //     {
        //         attackData.Result = AttackResults.Miss;
        //     }
        //
        //     return attackData;
        // }

        private static int CalcDamage(GameEntity attacker, GameEntity defender)
        {
            int damage = attacker.RollDamage();
            defender.Damage("Life", damage, null);
            
            return damage;
        }
    }
}
