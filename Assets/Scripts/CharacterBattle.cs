using System;
using Unity.VisualScripting;
using UnityEngine;
using CodeMonkey.Utils;

public class CharacterBattle : MonoBehaviour
{
    private CharacterBase characterBase;
    private State state;
    private Vector3 slideTargetPosition;
    private Action onSlideComplete;
    private bool isPlayerTeam;
    private GameObject selectionCircleGameObject;
    private SpriteRenderer spriteRenderer;
    private HealthSystem healthSystem;
    private World_Bar healthBar;
    //public Transform pfHealthBar;
    private enum State
    {
        Idle,
        Sliding,
        Busy
    }
    private void Awake()
    {
        characterBase = GetComponent<CharacterBase>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectionCircleGameObject = transform.Find("SelectionCircle").gameObject;
        HideSelectionCircle();
        state = State.Idle;
    }

    private void Update()
    {
        switch(state)
        {
            case State.Idle:
                // Idle behavior
                break;
            case State.Sliding:
                float slidespeed = 7f;
                transform.position += (slideTargetPosition - GetPosition()) * slidespeed * Time.deltaTime;

                float reachTargetDistance = 1f;
                if (Vector3.Distance(GetPosition(), slideTargetPosition) < reachTargetDistance)
                {
                    transform.position = slideTargetPosition;
                    onSlideComplete();
                }
                break;
            case State.Busy:
                // Busy behavior
                break;
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Setup(bool isPlayerTeam)
    {
        this.isPlayerTeam = isPlayerTeam;
        characterBase.SetDefaultFacingRight(isPlayerTeam);
        healthSystem = new HealthSystem(GameAssets.i.pfFighterStatsPrefab.GetComponent<FighterStats>().health);
        // Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(characterBase.transform.position.x - 1, -0.5f), Quaternion.identity);
        //healthBar = healthBarTransform.GetComponent<HealthBar>();
        //healthBar.Setup(healthSystem);
        healthBar = new World_Bar(transform, new Vector3(0, 2), new Vector3(1.5f, 0.2f), Color.grey, Color.red, 1f, 100, new World_Bar.Outline { color = Color.black, size = 0.2f });
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        PlayAnimIdle();
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        healthBar.SetSize(healthSystem.GetHealthPercent());
    }

    private void PlayAnimIdle()
    {
        if (isPlayerTeam)
        {
            characterBase.PlayAnimIdle(new Vector3(-1, 0));
        }
        else
        {
            characterBase.PlayAnimIdle(new Vector3(1, 0));
        }
    }

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        //CodeMonkey.CMDebug.TextPopup("Hit " + healthSystem.GetHealthAmount(), GetPosition());
        //Debug.Log(name + " took damage, current health: " + healthSystem.GetHealthAmount());
        DamagePopUp.Create(GetPosition(), damageAmount, false);
        characterBase.SetColorTint(new Color(1, 0, 0, 1f));

        // Applies screen shake effect
        CodeMonkey.Utils.UtilsClass.ShakeCamera(0.1f, 0.1f);

        if ( healthSystem.isDead())
        {
            // Died
            characterBase.PlayAnimDie();
        }
        else
        {
            characterBase.PlayAnimHurt();
        }
    }

    public bool IsDead()
    {
        return healthSystem.isDead();
    }

    public void Attack(CharacterBattle targetCharacterBattle,string abilityName, Action onAttackComplete)
    {
        HideAttackButtons();
        Vector3 offsetDir = (GetPosition() - targetCharacterBattle.GetPosition()).normalized;
        Vector3 slideTargetPosition = targetCharacterBattle.GetPosition() + offsetDir * 2f;
        Vector3 originalPosition = GetPosition();
        Vector3 targetpos = targetCharacterBattle.GetPosition();

        //Slide to target
        SlideToPosition(slideTargetPosition, () =>
        {

            //Arrival at target, play attack animation
            state = State.Busy;
            Vector3 attackDir = (targetCharacterBattle.GetPosition() - GetPosition()).normalized;
            characterBase.PlayAnimAttack(attackDir, abilityName, () =>
            {
                int dmageAmount = UnityEngine.Random.Range(30,40);
                // Target Hit
                Debug.Log(name + " attacked " + targetCharacterBattle.name);
                targetCharacterBattle.Damage(dmageAmount);
            },
                () => {
                    // Attack completed, slide back
                    SlideToPosition(originalPosition, () =>
                    {
                        // on complete
                        Debug.Log("Attack animation complete for " + name);
                        // Slide back complete, play idle animation
                        state = State.Idle;
                        this.PlayAnimIdle();

                        // Call the provided callback to signal that the attack is complete
                        onAttackComplete();
                    });
                });
        });
    }

    private void SlideToPosition(Vector3 targetPosition, Action onSlideComplete)
    {
        spriteRenderer.sortingOrder = 1; // Bring to front while sliding
        this.slideTargetPosition = targetPosition;
        this.onSlideComplete = onSlideComplete;
        state = State.Sliding;

        if (slideTargetPosition.x > 0)
        {
            characterBase.PlayAnimSlideRight();
        }
        else
        {
            
            characterBase.PlayAnimSlideLeft();
        }
    }

    public bool IsPlayerTeam()
    {
        return isPlayerTeam;
    }

    public void HideSelectionCircle()
    {
        selectionCircleGameObject.SetActive(false);
    }
    public void ShowSelectionCircle()
    {
        selectionCircleGameObject.SetActive(true);
    }

    private void HideAttackButtons()
    {

        AbilityButtonManager.HideStatic();
    }
}
