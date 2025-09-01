using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
public class DamagePopUp : MonoBehaviour
{

    

    // Create a Damage Popup
    public static DamagePopUp Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.pfDamagePopUp, position, Quaternion.identity);

        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damageAmount, isCriticalHit);

        return damagePopUp;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;
    private TextMeshPro textMesh;
    private Vector3 moveVector;
    private float disappearTimer;
    private Color textColor;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount, bool isCriticalHit)
    {
        textMesh.SetText(damageAmount.ToString());
        if (isCriticalHit)
        {
            // Critical hit
            textMesh.fontSize = 7;
            textColor = UtilsClass.GetColorFromString("FF2B00");
        }
        else
        {
            // Normal hit
            textMesh.fontSize = 5;
            textColor = UtilsClass.GetColorFromString("FFC500");
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        // Makes each later popup appear on top of the previous one
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        // This vector controls the direction and speed of the popup
        moveVector = new Vector3(0.7f, 1) * 2f;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            // First half of the popup
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of the popup
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
