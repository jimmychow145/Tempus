using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    

    public int GetValue()
    {
        return baseValue;
    }

    public void AddValue(int value)
    {
        baseValue += value;
    }
    public void Reset(int value)
    {
        baseValue = value;
    }
    
}