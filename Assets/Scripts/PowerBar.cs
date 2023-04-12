using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Image image;
    [Tooltip("does this mean that 10 tiles will fill bar? if so write so :D")]
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
}
