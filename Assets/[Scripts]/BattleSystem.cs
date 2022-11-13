using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
    public float EnemyCoolDownMax;
    private float EnemyCoolDown;

    [Header("Ability Settings")]
    public GameObject ButtonPrefab;
    public Transform ButtonParent;

    private void Start()
    {
        EnemyCoolDown = EnemyCoolDownMax;
        CreateButtons();
    }
    // Update is called once per frame
    void Update()
    {
        if(!IsPlayerTurn)
            EnemyCoolDown -= Time.deltaTime;
        if (!IsPlayerTurn && EnemyCoolDown <= 0.0f)
        {
            EnemysTurn();
            EnemyCoolDown = EnemyCoolDownMax;
        }
    }
    public void EnemysTurn()
    {
        //Eenemy AI Here...
        Debug.Log("Passed");
        IsPlayerTurn = true;
    }
    private void CreateButtons()
    {
        foreach (Abilitys ability in PlayerAbilitys)
        {
            GameObject goTemp = ButtonPrefab;
            goTemp.GetComponent<AbilityButton>().ability = ability;
            GameObject.Instantiate(goTemp, Vector3.zero, Quaternion.identity, ButtonParent);
        }
    }
}
