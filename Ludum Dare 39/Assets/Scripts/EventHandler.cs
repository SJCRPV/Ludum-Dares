using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    private EventList eventList;
    private int listSize;

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
        //return eventList.getEvent(Random.Range(1, listSize - 1));
        return eventList.getEvent(1);
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
