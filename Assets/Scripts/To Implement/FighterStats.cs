using UnityEngine;
using UnityEngine.UI;
using System;
//public class FighterStats : MonoBehaviour , IComparable
public class FighterStats : MonoBehaviour
{
    /*[SerializeField] private Animator animator;

    // images that represent the health and mana of the player
    [SerializeField] private GameObject healthFill;
    [SerializeField] private GameObject magicFill;*/

    // creates a header inside unity editor
    [Header("Stats")]
    public int health;
    public int melee;
    public int defense;
    public int experience;


    /*public float magic;
    public float magicRange;
    public float speed;
    private float startHealth;
    private float startMagic;

    [HideInInspector] public int nextActTurn;
    
    // Resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private bool dead = false;
    private GameObject GameControllerObj;

    private void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        magicTransform = healthFill.GetComponent<RectTransform>();
        GameControllerObj = GameObject.Find("GameControllerObject");

        healthScale = healthFill.transform.localScale;
        magicScale = healthFill.transform.localScale;

        startHealth = health;
        startMagic = magic;
    }

    /*public void ReceiveDamage(float damage)
    {
        health -= damage;
        animator.Play("Hurt");

        // Set Damage txt

        if (health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }
        else if (damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }

        if (damage > 0)
        {
            GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
            GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
        }
        // Calls the ContinueGame function after 2 seconds
        Invoke("ContinueGame", 2);
    }

    public void UpdateMagicFill(float cost)
    {
        
        if (cost > 0)
        {
            magic -= cost;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
        }


        
    }

    public bool GetDead()
    {
        return dead;
    }

    void ContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
    public void CalculateNextTurn(int currentTurn)
    {
        // round up to an integer but the ceiling of it
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStats)
    {
        int next = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return next;
    }*/


}
