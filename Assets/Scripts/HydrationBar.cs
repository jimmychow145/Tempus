using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydrationBar : MonoBehaviour
{
    public Slider slider;

    public void SetHydration(float hydration)
    {
        slider.value = hydration;
    }


}
