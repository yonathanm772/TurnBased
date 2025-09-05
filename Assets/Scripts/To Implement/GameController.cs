using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    /*private List<FighterStats> fighterStats;

    // the option menu to make the player attack
    private GameObject battleMenu;

    public Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
    }
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        // Fastest character in the list based on speed 
        FighterStats currentFighterStats = fighterStats[0];
        // Removes that object from the list
        fighterStats.Remove(currentFighterStats);

        if (!currentFighterStats.GetDead())
        {
            // grabs the game object of the current unit
            GameObject currentUnit = currentFighterStats.gameObject;
            // Calculate the next turn of this unit using the currentFighterStats.nextActTurn function
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            // Adds that object back
            fighterStats.Add(currentFighterStats);
            // Sort the list according to speed
            fighterStats.Sort();

            if(currentUnit.tag == "Hero")
            {
                // Shows the menu while is the Hero's turn, otherwise, it hides it
                this.battleMenu.SetActive(true);
            }
            else
            {
                this.battleMenu.SetActive(false);
                // decides the attack of the enemy
                // Random.Range goes from (0 to 2-1=1)
                string attackType = Random.Range(0, 2) == 1 ? "melee" : "range";
                // The computer selects the attack for the enemy
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            NextTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
