using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    private EventList eventList;
    private int listSize;

    public int ListSize
    {
        get
        {
            return listSize;
        }
    }

    public Event grabEvent(int index)
    {
        if(index != -1)
        {
            return eventList.getEvent(index);
        }
        Debug.LogError("I was given a -1. Error.");
        return null;
    }

    public Event grabEvent()
    {
        Event returnEvent;
        do
        {
            returnEvent = eventList.getEvent(Random.Range(1, listSize - 1));
        } while (returnEvent.getIsResponseEvent());

        return returnEvent;
    }

    void Start()
    {
        eventList = gameObject.GetComponent<EventList>();
        listSize = EventList.getListSize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
