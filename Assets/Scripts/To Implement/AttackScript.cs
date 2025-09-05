using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // the game object holding the script
    public GameObject owner;

    [SerializeField] private string animationName;

    // if the user has a magic attack (it could be melee or ranged), its true, and it costs magic points
    //[SerializeField] private bool magicAttack;
    //[SerializeField] private float magicCost;

    // multipliers to add fun to the game
    [SerializeField] private float minAttackMultiplier;
    [SerializeField] private float maxAttackMultiplier;

    // multipliers to add fun to the game
    [SerializeField] private float minDefenseMultiplier;
    [SerializeField] private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    
    /*public void Attack(GameObject victim)
    {
        
        // attack stats of the owner
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

        // damg of the attack
        damage = multiplier * attackerStats.melee;
        // however, if it is a magic attack, do the multiplier;
        if (magicAttack)
        {
            damage = multiplier * attackerStats.magicRange;
        }

        float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);

        // Take the dame calculated and substract the defense multiplier * the defense
        damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

        owner.GetComponent<Animator>().Play(animationName);
        targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
        attackerStats.UpdateMagicFill(magicCost);

        // checks if the user has enough mana to cast the spell
        /*if (attackerStats.magic >= magicCost) 
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

            // damg of the attack
            damage = multiplier * attackerStats.melee;
            // however, if it is a magic attack, do the multiplier;
            if ( magicAttack )
            {
                damage = multiplier * attackerStats.magicRange;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            
            // Take the dame calculated and substract the defense multiplier * the defense
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.UpdateMagicFill(magicCost);

        }
        else
        {
            Invoke("SkipTurnContinueGame", 2);
        }

    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }*/
}


