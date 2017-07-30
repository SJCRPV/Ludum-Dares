using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    [SerializeField]
    private EventList eventList;
    private int listSize;

    public Event grabEvent()
    {
        return eventList.getEvent(Random.Range(1, listSize - 1));
    }

    void Start()
    {
        listSize = EventList.getListSize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
