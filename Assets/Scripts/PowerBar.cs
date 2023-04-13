using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Image slider;
    public float steps = 10f;

    public void FillPowerBar(float amount=1)
    {
        amount = amount / steps;
        if(slider.fillAmount != 1)
        {
        slider.fillAmount = slider.fillAmount + amount;
            if (slider.fillAmount == 1)
            {
                FindObjectOfType<AudioManager>().Play("PowerBarFull");
            }
        }
    }

    public bool UsePowerBar()
    {
        if (slider.fillAmount == 1)
        {
            slider.fillAmount = 0;
            return true;
        }
        return false;
    }
    public void SetColor(Color color)
    {
        slider.color = color;
    }
}
