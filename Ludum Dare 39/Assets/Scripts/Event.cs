using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {

    private string title;
    private string eventDescription;
    private EventOption[] eventOptions;
    private Effect[] optionEffects;
    private int[] valueChanges;
    private bool isResponseEvent;

    public bool getIsResponseEvent()
    {
        return isResponseEvent;
    }
    public string getTitle()
    {
        return title;
    }
    public string getEvDescription()
    {
        return eventDescription;
    }
    public string getEvOptionsString()
    {
        string retString = "";
        for(int i = 0; i < eventOptions.Length; i++)
        {
            retString += eventOptions[i].getOptionText() + "\n";
        }

        return retString;
    }
    public EventOption[] getEvOptions()
    {
        return eventOptions;
    }

    public void fireOption(int optionNum)
    {
        optionEffects = eventOptions[optionNum].getOptionEffects();
        valueChanges = eventOptions[optionNum].getValueChanges();
        for (int i = 0; i < optionEffects.Length; i++)
        {
            optionEffects[i].changeVarValue(valueChanges[i]);
        }
    }

    public Event(string evTitle, string evDes, EventOption[] evOps, bool nIsResponseEvent)
    {
        title = evTitle;
        eventDescription = evDes;
        eventOptions = evOps;
        isResponseEvent = nIsResponseEvent;
    }
}
