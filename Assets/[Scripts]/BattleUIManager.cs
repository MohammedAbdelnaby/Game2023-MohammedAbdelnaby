using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleUIManager : MonoBehaviour
{
    private BattleSystem Battle;

    [Header("Player UI")]
    public TMP_Text PlayerHealth;
    public TMP_Text PlayerMana;
    public TMP_Text PlayerArmour;

    [Header("Enemy UI")]
    public TMP_Text EnemyHealth;
    public TMP_Text EnemyMana;
    public TMP_Text EnemyArmour;

    private void Start()
    {
        Battle = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    private void Update()
    {
        //Player UI
        PlayerHealth.text = "Health: " + Battle.PlayerHealth;
        PlayerMana.text =   "Mana: " +   Battle.PlayerMana;
        PlayerArmour.text = "Armour: " + Battle.PlayerArmour;

        //Enemy UI
        EnemyHealth.text =  "Health: " + Battle.EnemyHealth;
        EnemyMana.text =    "Mana: " +   Battle.EnemyMana;
        if (Battle.EnemyArmour < 0)
        {
            EnemyArmour.text = "Armour: 0";
        }
        else
        {
            EnemyArmour.text = "Armour: " + Battle.EnemyArmour;
        }
    }
}
