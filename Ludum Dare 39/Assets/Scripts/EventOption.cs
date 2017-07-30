using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOption {

    private string optionText;
    private Effect[] optionEffects;
    private int[] valueChanges;
    private int jumpsToEventNum;

    public string getOptionText()
    {
        return optionText;
    }

    public Effect[] getOptionEffects()
    {
        return optionEffects;
    }
    public Effect getOptionEffectAt(int i)
    {
        return optionEffects[i];
    }

    public int[] getValueChanges()
    {
        return valueChanges;
    }

    public int getValueChangesAt(int i)
    {
        return valueChanges[i];
    }

    public EventOption(string nOptionText, Effect[] nOptionEffects, int[] nValueChanges, int nJumpsToEventNum)
    {
        optionText = nOptionText;
        optionEffects = nOptionEffects;
        valueChanges = nValueChanges;
        jumpsToEventNum = nJumpsToEventNum;
    }
}
