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

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        dialogueText.text = "Try to defeat this " + enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        enemyUnit.TakeDamage(playerUnit.damage);

        yield return new WaitForSeconds(2f);

        // Check if the enemy is dead
        // Change state based on what happended
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }
}
