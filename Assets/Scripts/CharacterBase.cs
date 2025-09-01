using Unity.VisualScripting;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    public bool defaultFacingRight;
    private CharacterBattle characterBattle;
    // Add these fields to your class:
    private System.Action onHitCallback;
    private System.Action onCompleteCallback;
    

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        characterBattle = GetComponent<CharacterBattle>();
        defaultFacingRight = characterBattle.IsPlayerTeam();

        

    }

    public void PlayAnimSlideRight()
    {
        if (myAnimator != null)
        {
            if(!defaultFacingRight)
            {
                FlipSprite(!defaultFacingRight);
                //mySpriteRenderer.flipX = true;

            }
            
            myAnimator.SetTrigger("Move");
        }
    }

    public void PlayAnimSlideLeft()
    {
        if (myAnimator != null)
        {
            if (defaultFacingRight)
            {
                FlipSprite(!defaultFacingRight);
                //mySpriteRenderer.flipX = true;
            }

            myAnimator.SetTrigger("Move");
        }
    }

    public void PlayAnimAttack(Vector3 attackDir, System.Action onHit, System.Action onComplete)
    {
        // Flip sprite based on attack direction
        if (mySpriteRenderer != null)
        {
            if (attackDir.x == 1)
            {
                //mySpriteRenderer.flipX = false;
                FlipSprite(defaultFacingRight);
            }
            else if (attackDir.x == -1)
            {
                //mySpriteRenderer.flipX = true;
                FlipSprite(defaultFacingRight);   
            }
                   
        }

        // Store callbacks for use in animation events
        this.onHitCallback = onHit;
        this.onCompleteCallback = onComplete;

        // Trigger attack animation
        if (myAnimator != null)
        {
            myAnimator.SetTrigger("Melee");
        }
    }

    // These methods should be called from Animation Events in your attack animation:
    public void OnAttackHit()
    {
        onHitCallback?.Invoke();
    }

    public void OnAttackComplete()
    {
        onCompleteCallback?.Invoke();
    }

    public void PlayAnimIdle(Vector3 facingDir)
    {

        mySpriteRenderer.sortingOrder = 0; // Bring to the back when idle
        // Flip sprite based on direction, if relevant
        if (facingDir.x == 1)
        {
            //mySpriteRenderer.flipX = true;
            FlipSprite(defaultFacingRight);
        }
        else if (facingDir.x == -1)
        {
            //mySpriteRenderer.flipX = false;
            FlipSprite(defaultFacingRight);
        }

        // Play the Idle animation
        if (myAnimator != null)
        {
            myAnimator.Play("Idle");
        }
    }

    public void PlayAnimHurt()
    {
        //mySpriteRenderer.sortingOrder = 1; // Bring to the front when dying
        if (myAnimator != null)
        {
            myAnimator.SetTrigger("Hurt");
        }
    }

    public void PlayAnimDie()
    {
        //mySpriteRenderer.sortingOrder = 1; // Bring to the front when dying
        if (myAnimator != null)
        {
            myAnimator.SetBool("Death", true);
        }
    }

    public void FlipSprite(bool isPlayerTeam)
    {
        if (isPlayerTeam)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void SetDefaultFacingRight(bool isPlayerTeam)
    {
        defaultFacingRight = isPlayerTeam;
    }

    // etColorTint(new Color(1, 0, 0, 1f);
    public void SetColorTint(Color color)
    {
        if (mySpriteRenderer != null)
        {
            mySpriteRenderer.color = color;
            Invoke("ResetColorTint", 0.2f); // Reset color after 0.2 seconds
        }
    }

    private void ResetColorTint()
    {
        if (mySpriteRenderer != null)
        {
            mySpriteRenderer.color = Color.white; // Reset to default color
        }
    }
}

