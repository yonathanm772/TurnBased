using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
public class AbilityButton : MonoBehaviour
{
    /* [SerializeField] private bool physical;

     private GameObject hero;
     private GameObject enemy;

     private static AbilityButton instance;

     private void Awake()
     {
         instance = this;
         //Hide();
     }

     private void Hide()
     {
         gameObject.SetActive(false);
     }

     private void Show()
     {
         gameObject.SetActive(true);
     }

     public static void ShowStatic()
     {
         instance.Show();
     }
     public static void HideStatic()
     {
         instance.Hide();
     }

     // Start is called once before the first execution of Update after the MonoBehaviour is created

     private void Start()
     {
         // It grabs the hero

         string temp = gameObject.name;


         hero = GameObject.FindGameObjectWithTag("Hero");
         enemy = GameObject.FindGameObjectWithTag("Enemy");

         if (hero == null)
         {
             Debug.LogError("Hero object not found. Is it tagged 'Hero' and active in the scene?");
             return;
         }

         if (enemy == null)
         {
             Debug.LogError("Enemy object not found. Is it tagged 'Enemy' and active in the scene?");
             return;
         }

         // Gets the Button component of the object attached to this script
         // and on Click, attach a callback to our object
         gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));

     }

     private void AttachCallback(string btn)
     {
         string temp = "Ability";
         // It 
         if (hero.GetComponent<CharacterBattle>() && enemy.GetComponent<CharacterBattle>())
         {
             hero.GetComponent<FighterAction>().SelectAttack(temp + "btn");
             Debug.Log("Button clicked: " + temp + "btn");
             hero.GetComponent<CharacterBattle>().Attack(enemy.GetComponent<CharacterBattle>(), () => { BattleHandler.i.ChooseNextActiveCharacter(); });
         }
         /**if (btn.CompareTo("MeleeBtn") == 0)
         {

             if(hero.GetComponent<CharacterBattle>() && enemy.GetComponent<CharacterBattle>())
             {
                 //hero.GetComponent<FighterAction>().SelectAttack("Melee");
                 hero.GetComponent<CharacterBattle>().Attack(enemy.GetComponent<CharacterBattle>(), () => { BattleHandler.i.ChooseNextActiveCharacter(); });
             }
             //
         }
         else if (btn.CompareTo("RangeBtn") == 0)
         {
             hero.GetComponent<FighterAction>().SelectAttack("range");
         }
         else
         {
             hero.GetComponent<FighterAction>().SelectAttack("run");
         }
     }*/

    private Button button;
    private GameObject hero;
    private GameObject enemy;

    private void Awake()
    {
        //gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
    }

    private void Start()
    {

        string temp = gameObject.name;

        button = GetComponent<Button>();

        button.onClick.AddListener(() => OnButtonClicked(temp));
    }

    private void OnButtonClicked(string temp)
    {

        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (hero.GetComponent<CharacterBattle>() && enemy.GetComponent<CharacterBattle>())
        {
            //hero.GetComponent<FighterAction>().SelectAttack("Ability"+temp);
            Debug.Log("Button clicked: " + "Ability" + temp);
            hero.GetComponent<CharacterBattle>().Attack(enemy.GetComponent<CharacterBattle>(), "Ability" + temp, () => { BattleHandler.i.ChooseNextActiveCharacter(); });
        }
    }
}
