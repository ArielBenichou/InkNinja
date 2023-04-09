using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Image image;
    public float steps = 10f;

    public void FillPowerBar(float amount)
    {
        amount = amount / steps;
        image.fillAmount = image.fillAmount + amount;
    }

    public bool UsePowerBar()
    {
        if (image.fillAmount == 1)
        {
            image.fillAmount = 0;
            return true;
        }
        return false;
    }
    void Update()
    {
        FillPowerBar(1);
    }
}
