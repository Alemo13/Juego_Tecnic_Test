using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleStates { Start, PlayerTurn, EnemyTurn, Won, Lose }
public class BattleSystem : MonoBehaviour
{
    public BattleStates state;
    public BattleSystemSO battleSystemSO;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private UnitManager playerUnit;
    private UnitManager enemyUnit;

    public GameObject stateWindow;

    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI stateMessage;

    public BattleHub playerHub;
    public BattleHub enemyHub;

    void Start()
    {
        state = BattleStates.Start;
        StartCoroutine(SetUpBattle());
    }

    private IEnumerator SetUpBattle()
    {
        if(state == BattleStates.Start)
        {
            stateWindow.SetActive(true);
            stateMessage.text = "Battle Started";
            yield return new WaitForSeconds(2f);
        }
        GameObject playerGO = Instantiate(battleSystemSO.playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<UnitManager>();
        playerName.text = playerUnit.name;

        GameObject enemyGO = Instantiate(battleSystemSO.enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<UnitManager>();
        enemyName.text = enemyUnit.name;

        playerHub.SetHUD(playerUnit);
        enemyHub.SetHUD(enemyUnit);

        //yield return new WaitForSeconds(2f);
        
        state = BattleStates.PlayerTurn;
        StartCoroutine(PlayerTurn());
    }

    private IEnumerator EnemyTurn(float rng)
    {
        stateWindow.SetActive(true);
        stateMessage.text = "Enemy Turn";
        yield return new WaitForSeconds(2f);
        if(Random.value >= rng)
        {
            StartCoroutine(EnemyAttack(enemyUnit.damage));
        }else
        {
            StartCoroutine(EnemyAttack(enemyUnit.magic * 2));
        }     
    }
    private IEnumerator EnemyAttack(int dmg)
    {
        bool playerIsDead;
        if (playerUnit.isDef) //If the player is defended, we calculate the difference between the enemy damage and player defense
        {
            if (dmg < playerUnit.def) //If def is greater than the enemy damage, the damage take is 1
            {
                dmg = 1;
                playerIsDead = playerUnit.TakeDamage(dmg);
                stateMessage.text = "Enemy Deals you Damage: " + dmg;
                yield return new WaitForSeconds(2f);
                playerUnit.isDef = false;
                playerHub.SetHP(playerUnit.currentHealth);
            }
            else //otherwise, the damage is the substraction of the enemy damage and the player defense
            {
                dmg -= playerUnit.def;
                playerIsDead = playerUnit.TakeDamage(dmg);
                stateMessage.text = "Enemy Deals you Damage: " + dmg;
                yield return new WaitForSeconds(2f);
                playerUnit.isDef = false;
                playerHub.SetHP(playerUnit.currentHealth);
            }
        }
        else //If the player is not defended, the player take all the enemy damage
        {
            playerIsDead = playerUnit.TakeDamage(dmg);
            stateMessage.text = "Enemy Deals you Damage: " + dmg;
            yield return new WaitForSeconds(2f);
            playerHub.SetHP(playerUnit.currentHealth);
        }
        if (playerIsDead)
        {
            state = BattleStates.Lose;
            EndBattle();
        }
        else
        {
            state = BattleStates.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
        yield return new WaitForSeconds(2f);
    }
    private IEnumerator PlayerAttack(int dmg, string type)
    {
        bool enemyIsDead;
        if (type == "damage")
        {
            enemyIsDead = enemyUnit.TakeDamage(dmg);
            stateWindow.SetActive(true);       
            stateMessage.text = "Successful Attack: " + dmg;
            yield return new WaitForSeconds(2f);
            stateWindow.SetActive(false);    
            enemyHub.SetHP(enemyUnit.currentHealth);
        } else if (type == "magic")
        {
            dmg *= 2;
            enemyIsDead = enemyUnit.TakeDamage(dmg);
            stateWindow.SetActive(true);        
            stateMessage.text = "Successful Magic Attack: " + dmg;
            yield return new WaitForSeconds(2f);
            stateWindow.SetActive(false);
            enemyHub.SetHP(enemyUnit.currentHealth);
        }
        if (enemyIsDead)
        {
            state = BattleStates.Won;
            EndBattle();
        } else
        {
            state = BattleStates.EnemyTurn;
            if(enemyUnit.damage > enemyUnit.magic)
            {
                StartCoroutine(EnemyTurn(0.3f));
            }else
            {
                StartCoroutine(EnemyTurn(0.7f));
            }        
        }
    }
    private IEnumerator PlayerDefends()
    {
        stateWindow.SetActive(true);
        stateMessage.text = "You Defended";
        yield return new WaitForSeconds(1f);

        playerUnit.isDef = true;
        state = BattleStates.EnemyTurn;
        if (enemyUnit.damage > enemyUnit.magic)
        {
            StartCoroutine(EnemyTurn(0.3f));
        }
        else
        {
            StartCoroutine(EnemyTurn(0.7f));
        }
    }
    private void EndBattle()
    {
        if(state == BattleStates.Won)
        {
            stateWindow.SetActive(true);
            stateMessage.text = "YOU WON!";
        } else if (state == BattleStates.Lose)
        {
            stateWindow.SetActive(true);
            stateMessage.text = "YOU LOSE!!";
        }
    }

    private IEnumerator PlayerTurn()
    {
        stateWindow.SetActive(true);
        stateMessage.text = "Player Turn";
        yield return new WaitForSeconds(1f);
        stateWindow.SetActive(false);

    }
    public void OnAttackButton()
    {
        if(state != BattleStates.PlayerTurn)
            return;
        StartCoroutine(PlayerAttack(playerUnit.damage, "damage"));

    }
    public void OnMagicButton()
    {
        if (state != BattleStates.PlayerTurn)
            return;
        StartCoroutine(PlayerAttack(playerUnit.magic, "magic"));
    }
    public void OnDefenseButton()
    {
        if (state != BattleStates.PlayerTurn)
            return;
        StartCoroutine(PlayerDefends());
    }
}
