using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleUIManager : MonoBehaviour
{
    private BattleSystem Battle;

    public TMP_Text PlayerHealth;
    public TMP_Text PlayerMana;
    public TMP_Text EnemyHealth;
    public TMP_Text EnemyMana;

    private void Start()
    {
        Battle = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    private void Update()
    {
        PlayerHealth.text = "Health: " + Battle.PlayerHealth;
        PlayerMana.text =   "Mana: " +   Battle.PlayerMana;
        EnemyHealth.text =  "Health: " + Battle.EnemyHealth;
        EnemyMana.text =    "Mana: " +   Battle.EnemyMana;
    }
}
