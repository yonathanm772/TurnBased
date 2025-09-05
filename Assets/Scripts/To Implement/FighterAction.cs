using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    //[SerializeField] private GameObject meleePrefab;
    //[SerializeField] private GameObject rangePrefab;

    private GameObject currentAttack;


    private void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void SelectAttack(string attackName)
    {
        // If the tag is equal to Hero, then the victim is the enemy
        GameObject victim = hero;

        if (tag == "Hero")
        {
            victim = enemy;
        }
        // Comparing to 0 basically means that it is the same
        if (attackName.CompareTo("Melee") == 0)
        {
            Debug.Log("Button clicked: " + attackName);
            //GameAssets.i.pfMeleePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (attackName.CompareTo("range") == 0)
        {
            //GameAssets.i.pfRangePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("Run");
        }
    }
}
