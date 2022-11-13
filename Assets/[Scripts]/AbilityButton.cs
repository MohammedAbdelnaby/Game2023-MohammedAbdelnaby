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
        if (Battle.IsPlayerTurn)
        {
            Battle.EnemyHealth -= ability.Damage;
            Battle.EnemyMana -= ability.ManaCost;
            Battle.IsPlayerTurn = false;
            Debug.Log(ability.name + ": " + ability.Description); 
        }
    }
}
