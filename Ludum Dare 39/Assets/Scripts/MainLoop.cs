using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour {

    private EventHandler eventHandler;
    private Event currentEvent;

    [SerializeField]
    private int secondsBetweenEvents;
    private float totalTime;
    [SerializeField]
    private float timeSinceLastEvent;
    private bool eventIsOpen;
    private int eventOptionsLength;

    //Maybe do without
    //private int powerLevel;
    //private int moraleLevel;
    //private int livesLeft;
    //private int livesLost;

    private void displayEvent(Event newEvent)
    {
        eventIsOpen = true;
    }

    private void fireEvent()
    {
        currentEvent = eventHandler.grabEvent();
        eventOptionsLength = currentEvent.getEvOptions().Length;
        Debug.Log("Fire! " + currentEvent.getEvOptions().Length);
        displayEvent(currentEvent);
    }

    private void checkForInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            currentEvent.fireOption(0);
        }

        if(eventOptionsLength > 1 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2");
            currentEvent.fireOption(1);
        }

        if(eventOptionsLength > 2 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
            currentEvent.fireOption(2);
        }
    }

    private void Start()
    {
        eventHandler = GameObject.Find("EventSystem").GetComponent<EventHandler>();
        eventIsOpen = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (eventIsOpen)
        {
            checkForInput();
        }
        else
        {
            totalTime += Time.deltaTime;
            timeSinceLastEvent += Time.deltaTime;

            if (timeSinceLastEvent > secondsBetweenEvents)
            {
                fireEvent();
                timeSinceLastEvent = 0;
            }
        }
	}
}
