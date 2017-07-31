using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSpeech : MonoBehaviour {

    private EventList eventList;
    private InputField inputField;
    private string finalSpeech;
    private bool finalEventComposed;

    private void composeFinalEvent()
    {
        //TODO: Adapt the player's speech alongside the story description. Grab bits from here and there, but put the entire speech in the event.
        EventOption evOp1 = new EventOption("1. Game Over.", new Effect[] { }, new int[] { }, -999);
        
        Event nEvent = new Event("The Speech", "It took you a couple of tries to start, but eventually you composed yourself.\n" + finalSpeech + "\nAs you spoke, some started crying; some started shouting; some didn't want to believe it. Soon after, the people started rioting. They demanded a new Captain, they refused to believe they were going to just die like that. There were fights, blood, deaths. The ship became a battlefield.\nIt wasn't long before a group was at the helm's door.\nThat only lasted so long. You and the others in the room tried to fight them off, but were overwhelmed. You remember getting hit. Some broken ribs, an arm, probably your nose; likely more, but eventually someone shot you in the head. A new Captain was elected after things calmed down, but that didn't have any luck either. They commited suicide.\nThe ship went silent a couple of months later and drifted in space without any power. The only ones still alive quickly went mad and died of either starvation or asphyxiation when the life support gave in.\n\nSo ends the story of this lone colony ship, doomed to aimlessly drift in space until it gets salvaged by some other species or crashes into a cosmic object.", new EventOption[] { evOp1 }, true);
        eventList.addEvent(nEvent);
        finalEventComposed = true;
    }

	// Use this for initialization
	void Start () {
        inputField = GameObject.Find("FSInput").GetComponent<InputField>();
        eventList = GameObject.Find("GameEventSystem").GetComponent<EventList>();
        finalEventComposed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!finalEventComposed)
            {
                finalSpeech = inputField.text;
                composeFinalEvent();
            }
            else
            {
                Application.Quit();
            }
        }
	}
}
