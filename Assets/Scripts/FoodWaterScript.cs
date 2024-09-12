using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodWaterScript : MonoBehaviour
{
    public float decRate;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= decRate * Time.deltaTime;
    }

    public void consumed(float amount)
    {
        slider.value += amount;
    }
}
