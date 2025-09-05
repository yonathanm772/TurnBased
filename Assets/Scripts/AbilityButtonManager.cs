using UnityEngine;

public class AbilityButtonManager : MonoBehaviour
{
    public static AbilityButtonManager i { get; private set; }

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
        i.Show();
    }
    public static void HideStatic()
    {
        i.Hide();
    }
}
