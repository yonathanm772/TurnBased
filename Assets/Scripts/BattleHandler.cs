using UnityEngine;
using UnityEngine.TextCore.Text;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler i { get; private set; }

    private void Awake()
    {
        if (i != null && i != this)
        {
            Destroy(gameObject);
            return;
        }
        i = this;
        // Optional: DontDestroyOnLoad(gameObject);
    }
    // prefab character (i.e. wizard)
    [SerializeField] private Transform pfCharacterBattle;
    [SerializeField] private Transform pfEnemyBattle;

    private CharacterBattle playerCharacterBattle;
    private CharacterBattle enemyCharacterBattle;
    private CharacterBattle activeCharacterBattle;
    private BattleState state;
    

    private enum BattleState
    {
        WaitingForPlayer,
        Busy,
        EnemyTurn,
        Victory,
        Defeat
    }
    private void Start()
    {
        playerCharacterBattle = SpawnCharacter(true);
        enemyCharacterBattle = SpawnCharacter(false);

        SetActiveCharacterBattle(playerCharacterBattle);
        state = BattleState.WaitingForPlayer;
    }

    private void Update()
    {
        if (state == BattleState.WaitingForPlayer)
        {
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                state = BattleState.Busy;
                playerCharacterBattle.Attack(enemyCharacterBattle, () =>
                {
                    ChooseNextActiveCharacter();
                });
            }*/
            /*if (MakeButton.Equals("MeleeBtn"))
            {
                state = BattleState.Busy;
                playerCharacterBattle.Attack(enemyCharacterBattle, () =>
                {
                    ChooseNextActiveCharacter();
                });
            }*/
        }
    }

    private CharacterBattle SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 heroPosition = new Vector3(-5, 0);
        Vector3 enemyPosition = new Vector3(+5, 0);

        if (isPlayerTeam)
        {
            Transform characterTransform = Instantiate(pfCharacterBattle, heroPosition, Quaternion.identity);
            CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
            characterBattle.Setup(isPlayerTeam);
            return characterBattle;
        }
        else
        {
            Transform enemyTransform = Instantiate(pfEnemyBattle, enemyPosition, Quaternion.identity);
            CharacterBattle enemyBattle = enemyTransform.GetComponent<CharacterBattle>();
            enemyBattle.Setup(isPlayerTeam);
            return enemyBattle;
        }

        
    }

    private void SetActiveCharacterBattle(CharacterBattle characterBattle)
    {
        if(activeCharacterBattle != null)
        {
            activeCharacterBattle.HideSelectionCircle();
        }
        activeCharacterBattle = characterBattle;
        activeCharacterBattle.ShowSelectionCircle();

    }

    public void ChooseNextActiveCharacter()
    {
        if (TestBattleOver())
        {
            return;
        }
        if (activeCharacterBattle == playerCharacterBattle)
        {
            SetActiveCharacterBattle(enemyCharacterBattle);
            state = BattleState.Busy;

            int randomAttack = Random.Range(0, 2); // Assuming there are 2 types of attacks for the enemy
            string abilityName = "Ability" + randomAttack;
            enemyCharacterBattle.Attack(playerCharacterBattle, abilityName, () =>
            {
                ChooseNextActiveCharacter();
            });
        }
        else
        {
            SetActiveCharacterBattle(playerCharacterBattle);
            state = BattleState.WaitingForPlayer;
            ShowAttackButtons();
        }
    }

    private bool TestBattleOver()
    {
        if (playerCharacterBattle.IsDead())
        {
            //state = BattleState.Defeat;
           //CodeMonkey.CMDebug.TextPopupMouse("Enemy Wins!");
            BattleOverWindow.ShowStatic("Enemy Wins!");
            return true;
        }
        if (enemyCharacterBattle.IsDead())
        {
            //state = BattleState.Victory;
            //CodeMonkey.CMDebug.TextPopupMouse("Player Wins!");
            BattleOverWindow.ShowStatic("Player Wins!");
            return true;
        }

        return false;
    }


    private void ShowAttackButtons()
    {
        AbilityButtonManager.ShowStatic();
    }
}
