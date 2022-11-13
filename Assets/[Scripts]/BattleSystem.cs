using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    [Header("Player")]
    public int PlayerHealth;
    public int PlayerMana;
    public List<Abilitys> PlayerAbilitys;

    [Header("Enemy")]
    public int EnemyHealth;
    public int EnemyMana;
    public List<Abilitys> EnemyAbilitys;

    [Header("System Settings")]
    public bool IsPlayerTurn;

    [Header("Ability Settings")]
    public GameObject ButtonPrefab;
    public Transform ButtonParent;

    private void Start()
    {
        CreateButtons();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayersTurn()
    {

    }

    public void EnemysTurn()
    {
        Debug.Log("Passed");
        IsPlayerTurn = true;
    }

    public void PlayerAbilityUse(Abilitys abilitys)
    {

    }

    private void CreateButtons()
    {
        foreach (Abilitys ability in PlayerAbilitys)
        {
            GameObject goTemp = ButtonPrefab;
            goTemp.GetComponent<Button>().onClick.AddListener(delegate () { PlayerAbilityUse(ability); });
            goTemp.transform.GetChild(0).GetComponent<TMP_Text>().text = ability.name;
            GameObject.Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, ButtonParent);
        }
    }
}
