using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stat
{
    public List<float> modifiers;
    public float basevalue;
    Stat(float basevalue)
    {
        this.basevalue=basevalue;
    }
    public float getValue()
    {
        float finalValue=basevalue;
        foreach(float value in modifiers)
        {
            finalValue+=value;
        }
        return finalValue;
    }
    public void addModifier(float modifier)
    {
        modifiers.Add(modifier);
    }

    public void removeModifier(float modifier)
    {
        modifiers.Remove(modifier);
    }

}

