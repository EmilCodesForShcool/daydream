using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} // public enum to save the game state
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab; // Allows you to drag the player prefab + enemy prefab into the inspector menu
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START; //get default state which is start
        StartCoroutine(SetupBattle()); //use co routines to create delay between initializing and starting gameplay
    }
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation); //Spawn the objects + make gameobject for ui changes
        playerUnit = playerGO.GetComponent<Unit>(); //Get the unit script to keep track of hp, damage, etc.

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation); //Create game objects
        enemyUnit = enemyGO.GetComponent<Unit>();
        dialogueText.text = "Try to defeat this " + enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); 

        state = BattleState.PLAYERTURN;
        PlayerTurn(); //Start the battle with the player's turn

    }

    IEnumerator PlayerAttack() //Attact function
    {
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentUnit);
        dialogueText.text = "Hit registered"

        yield return new WaitForSeconds(2f);

        // Check if the enemy is dead
        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();   //Stop the battle if you kill enemy
        {
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn()); //Switch to the enemy's turn
        }
    IENumerator EnemyTurn() //Function for enemy turn
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST; //If player dies, game over
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN; //Switch to the player's turn
            PlayerTurn();
        }
    }
    void EndBattle() //Function to display the battle's result
    {
        if(state== BattleState.WON)
        {
            dialogueText.text = "You won the battle!"
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost!"
        }

    IEnumerator PlayerHeal() //Heal button
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel refreshed";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    void PlayerTurn() //What to display on the player's turn
    {
        dialogueText.text = "Choose an action";
    }

    public void OnAttackButton() // Attack trigger, put it on the inspector
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton() //Heal trigger, put it on the inspector
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
