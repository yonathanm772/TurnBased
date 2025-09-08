using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public static int CalculateDamage(FighterStats attacker, FighterStats defender, string abilityName, bool isCritical)
    {
        if (attacker == null || defender == null)
        {
            Debug.LogError("Null FighterStats passed to CalculateDamage!");
            return 0;
        }

        Debug.Log($"Calculating damage for ability: {abilityName} from attacker: {attacker.name} to defender: {defender.name}");
        // Example logic, expand as needed for abilities
        float minAttackMultiplier = 1f;
        float maxAttackMultiplier = 2f;
        float minDefenseMultiplier = 0.5f;
        float maxDefenseMultiplier = 1f;

        switch (abilityName)
        {
            case "Ability0":
                minAttackMultiplier = 1f;
                maxAttackMultiplier = 1.5f;
                minDefenseMultiplier = 0.5f;
                maxDefenseMultiplier = 1f;
                break;
            case "Ability1":
                minAttackMultiplier = 1.5f;
                maxAttackMultiplier = 2f;
                minDefenseMultiplier = 0.3f;
                maxDefenseMultiplier = 0.8f;
                break;
            default:
                Debug.LogWarning($"Unknown ability name: {abilityName}. Using default multipliers.");
                break;
        }

        float attackMultiplier = UnityEngine.Random.Range(minAttackMultiplier, maxAttackMultiplier);
        float defenseMultiplier = UnityEngine.Random.Range(minDefenseMultiplier, maxDefenseMultiplier);

        float rawDamage = attackMultiplier * attacker.melee;
        float mitigatedDamage = Mathf.Max(0, rawDamage - (defenseMultiplier * defender.defense));

        if (isCritical)
        {
            mitigatedDamage *= 1.5f; // Critical hits deal 50% more damage
        }

        return Mathf.CeilToInt(mitigatedDamage);
    }

    public static bool isCritical(FighterStats attacker)
    {
        if (attacker == null)
        {
            Debug.LogError("Null FighterStats passed to isCritical!");
            return false;
        }
        int roll = UnityEngine.Random.Range(0, 100);
        return roll < attacker.criticalChance;
    }

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


