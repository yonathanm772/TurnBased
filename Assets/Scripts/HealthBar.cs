using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem heatlhSystem;
    private Transform bar;
    public void Setup(HealthSystem healthSystem)
    {
       this.heatlhSystem = healthSystem;
        bar = transform.Find("Bar");
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    public void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(heatlhSystem.GetHealthPercent(), 1);
    }

    public void SetSize(float scale)
    {
        //this.GetComponentInChildren<Transform>().localScale = new Vector3(scale, 1);
        bar.localScale = new Vector3(scale, 1);
    }

    private void Update()
    {
        
    }
}
