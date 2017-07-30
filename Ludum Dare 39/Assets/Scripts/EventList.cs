using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList : MonoBehaviour {

    private static List<Event> eventListArr;

    public static int getListSize()
    {
        return eventListArr.Count;
    }

    public Event getEvent(int index)
    {
        return eventListArr[index];
    }

    public void addEvent(Event nEvent)
    {
        eventListArr.Add(nEvent);
        Debug.Log("Added!");
    }

	// Use this for initialization
	void Start () {
        eventListArr = new List<Event>();
	}
}
