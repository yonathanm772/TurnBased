/**
 * Class: GameAssets
 * Allows to store and access game assets like prefabs and sounds.
 * Allows to access store and access all the refecences from one place.
 * 
*/
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if(_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _i;
        }
    }

    public Transform pfDamagePopUp;
    public Transform pfMeleePrefab;
    public Transform pfRangePrefab;
    public Transform pfFighterStatsPrefab;
}
