using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class BattleSystem : MonoBehaviour
{
    [Header("Player")]
    public int PlayerHealth;
    public int PlayerMana;
    public int PlayerArmour;
    public Buffs PlayerBuff;
    public Debuffs PlayerDebuff;
    public List<Abilitys> PlayerAbilitys;

    [Header("Enemy")]
    public int EnemyHealth;
    public int EnemyMana;
    public int EnemyArmour;
    public Buffs EnemyBuff;
    public Debuffs EnemyDebuff;
    public List<EnemyAbilities> EnemyAbilitys;

    [Header("System Settings")]
    public bool IsPlayerTurn;
    public float EnemyCoolDownMax;
    private float EnemyCoolDown;

    [Header("Ability Settings")]
    public GameObject ButtonPrefab;
    public Transform ButtonParent;

    public List<EnemyAbilities> AttackAbilities;
    public List<EnemyAbilities> DefenceAbilities;
    public List<EnemyAbilities> DebuffAbilities;
    public List<EnemyAbilities> BuffAbilities;

    private void Start()
    {
        EnemyCoolDown = EnemyCoolDownMax;
        CreateButtons();
        SplitAbilities();
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (EnemyHealth <= 0)
        {
            SceneManager.LoadScene("Game");
        }
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
        if (EnemyHealth <= 90)
        {
            DoEnemyAbility(RandomAbility(AttackAbilities));
            return;
        }
        else if (PlayerHealth < EnemyHealth && PlayerDebuff == Debuffs.NONE)
        {
            DoEnemyAbility(RandomAbility(DebuffAbilities));
            return;
        }
        else if (PlayerHealth > EnemyHealth  && EnemyBuff == Buffs.NONE)
        {
            DoEnemyAbility(RandomAbility(BuffAbilities));
            return;
        }
        else if(EnemyArmour < 0.0f)
        {
            DoEnemyAbility(RandomAbility(DefenceAbilities));
            return;
        }
        else
        {
            DoEnemyAbility(RandomAbility(AttackAbilities));
            return;
        }
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

    private void SplitAbilities()
    {
        for (int i = 0; i < EnemyAbilitys.Count; i++)
        {
            switch (EnemyAbilitys[i].Type)
            {
                case AbilityType.NONE:
                    break;
                case AbilityType.ATTACK:
                    AttackAbilities.Add(EnemyAbilitys[i]);
                    break;
                case AbilityType.DEFENCE:
                    DefenceAbilities.Add(EnemyAbilitys[i]);
                    break;
                case AbilityType.DEBUFF:
                    DebuffAbilities.Add(EnemyAbilitys[i]);
                    break;
                case AbilityType.BUFF:
                    BuffAbilities.Add(EnemyAbilitys[i]);
                    break;
                default:
                    break;
            }
        }
    }

    private EnemyAbilities RandomAbility(List<EnemyAbilities> list)
    {
        EnemyAbilities tempAbility = list[Random.Range(0, list.Count)];
        if (tempAbility.ManaCost > EnemyMana)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!(list[i].ManaCost >= EnemyMana))
                {
                    return list[i];
                }
            }
        }
        return tempAbility;
    }

    private void DoEnemyAbility(EnemyAbilities ability)
    {
        if (EnemyArmour > 0)
        {
            PlayerArmour -= ability.Armour;
        }
        else
        {
            PlayerHealth -= ability.Damage;
        }

        EnemyMana -= ability.ManaCost;
        EnemyArmour += ability.Armour;
        EnemyHealth += ability.Heal;
        PlayerDebuff = ability.Debuff;
        EnemyBuff = ability.Buff;
        IsPlayerTurn = true;
        Debug.Log(ability.name + ": " + ability.Description);
    }
}
