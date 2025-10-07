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
    public BattleState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START; //get default state which is start
        SetupBattle();
    }
    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation); //Spawn the objects + make gameobject for ui changes
        playerUnit = playerGO.GetComponent<Unit>(); //Get the unit script to keep track of hp, damage, etc.

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        if (enemyUnit.unitName != null)
        {
            dialogueText.text = "Try to defeat this " + enemyUnit.unitName;
        }
        else
        {
            Debug.Log("Damn the name is fucked");
        }
    }

}
