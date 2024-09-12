using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;

    public void SetHunger(float hunger)
    {
        slider.value = hunger;
    }



    
}
