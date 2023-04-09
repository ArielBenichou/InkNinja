using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Slider slider;
    public int steps = 10;
    public void FillPowerBar(float amount = (float) 1)
    {
        amount = amount / steps; 
        slider.value = slider.value + amount;
    }

    public bool UsePowerBar()
    {
        if (slider.value == 1)
        {
            slider.value = 0;
            return true;
        }
        return false;
    }
    void Start()
    {
        FillPowerBar(10);
    }
}
