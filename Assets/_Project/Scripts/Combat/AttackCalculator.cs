using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Enemies;
using UnityEngine;

namespace Descending.Combat
{
    public enum AttackResults { Critical_Hit, Hit, Graze, Miss, Fumble, Number, None }
    
    public static class AttackCalculator
    {
        public static AttackData ProcessAttack(Hero attacker, Enemy defender)
        {
            if (attacker.Attributes.GetVital("Actions").Current >= 1)
            {
                AttackData attackData = AttackResult(attacker.Attributes.GetStatistic("Attack").Current, defender.Attributes.GetStatistic("Dodge").Current);

                if (attackData.Result == AttackResults.Hit)
                {
                    attackData.Damage = CalcDamage(attacker, defender);
                    attacker.UseActions(1);
                    Debug.Log(attacker.GetName() + " hits " + defender.GetName() + " for " + attackData.Damage + " damage");
            
                    return attackData;
                }
            }

            return null;
        }
        
        public static AttackData ProcessAttack(Enemy attacker, Hero defender)
        {
            AttackData attackData = AttackResult(attacker.Attributes.GetStatistic("Attack").Current, defender.Attributes.GetStatistic("Dodge").Current);
            
            if (attackData.Result == AttackResults.Hit)
            {
                attackData.Damage = CalcDamage(attacker, defender);
                attacker.UseActions(1);
                
                Debug.Log(attacker.GetName() + " hits " + defender.GetName() + " for " + attackData.Damage + " damage");
            }
            
            return attackData;
        }
        
        private static AttackData AttackResult(int attack, int defense)
        {
            AttackData attackData = new AttackData();
            int attackRoll = Random.Range(0, 100) + attack;
            int defenseRoll = Random.Range(0, 100) + defense;
        
            attackData.AttackRoll = attackRoll;
            attackData.DefenseRoll = defenseRoll;
            
            if (attackRoll > defenseRoll)
            {
                attackData.Result = AttackResults.Hit;
            }
            else
            {
                attackData.Result = AttackResults.Miss;
            }
        
            return attackData;
        }

        private static int CalcDamage(GameEntity attacker, GameEntity defender)
        {
            int damage = attacker.RollDamage();
            defender.Damage("Life", damage, null);
            
            return damage;
        }
    }
}
