using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityButton : MonoBehaviour
{
    public Abilitys ability;
    private BattleSystem Battle;
    // Start is called before the first frame update
    void Start()
    {
        Battle = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        transform.GetChild(0).GetComponent<TMP_Text>().text = ability.name;
    }

    public void UseAbility()
    {
        if (Battle.IsPlayerTurn && Battle.PlayerMana >= ability.ManaCost)
        {
            if (Battle.EnemyArmour > 0)
            {
                Battle.EnemyArmour -= ability.Damage;
            }
            else
            {
                Battle.EnemyHealth -= ability.Damage;
            }

            Battle.PlayerMana -= ability.ManaCost;
            Battle.PlayerArmour += ability.Armour;
            Battle.PlayerHealth += ability.Heal;
            Battle.EnemyDebuff = ability.Debuff;
            Battle.PlayerBuff = ability.Buff;
            Battle.IsPlayerTurn = false;
            Debug.Log(ability.name + ": " + ability.Description); 
        }
    }
}
