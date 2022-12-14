using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/New Ability")]
public class Abilitys : ScriptableObject
{
    public string Name;
    public string Description;
    public Buffs Buff;
    public Debuffs Debuff;
    public int ManaCost;
    public int Damage;
    public int Armour;
    public int Heal;
}
