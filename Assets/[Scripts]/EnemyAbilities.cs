using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyAbility", menuName = "Ability/New EnemyAbility")]
public class EnemyAbilities : ScriptableObject
{
    public string Name;
    public string Description;
    public AbilityType Type;
    public Buffs Buff;
    public Debuffs Debuff;
    public int ManaCost;
    public int Damage;
    public int Armour;
    public int Heal;
}
