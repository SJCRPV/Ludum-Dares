using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLoop : MonoBehaviour {

    private EventHandler eventHandler;
    private Event currentEvent;
    private HUD hudScript;
    private GameObject eventObject;
    private Text eventTitle;
    private Text eventDescription;
    private Text eventOptions;
    private TextScroll textScrollScript;
    [SerializeField]
    private int powerGain = 5;
    [SerializeField]
    private float secBetweenEvents = 60f;
    [SerializeField]
    private float secBetweenRGain = 15f;
    private float secBetweenEventsStore;
    private float secBetweenRGainStore;
    private float startTime;
    private float totalTime;
    private bool eventIsOpen;
    private bool isDoingFinalSpeech;
    private bool shownFirstEvent;
    private int eventOptionsLength;

    private void addPower()
    {
        PowerEffect.staticChangeVarValue(powerGain);
        textScrollScript.gameObject.GetComponent<Text>().text = "+" + powerGain + " Power";
        textScrollScript.startScrolling();
        hudScript.updatePower();
    }

    private void displayEvent(Event nEvent)
    {
        eventIsOpen = true;
        eventObject.SetActive(true);
        eventTitle.text = nEvent.getTitle();
        eventDescription.text = nEvent.getEvDescription();
        eventOptions.text = nEvent.getEvOptionsString();
    }

    private void fireEvent()
    {
        hudScript.flipHUDVis();
        if(!shownFirstEvent)
        {
            currentEvent = eventHandler.grabEvent(0);
            shownFirstEvent = true;
        }
        else
        {
            currentEvent = eventHandler.grabEvent();
        }
        eventOptionsLength = currentEvent.getEvOptions().Length;
        Debug.Log("Fire! " + eventOptionsLength);
        displayEvent(currentEvent);
    }

    private void updateValuesInHUD(Effect[] effects)
    {
        for(int i = 0; i < effects.Length; i++)
        {
            if(effects[i].ToString().Equals(PowerEffect.ToString))
            {
                hudScript.updatePower();
            }
            else if(effects[i].ToString().Equals(LivesEffect.ToString))
            {
                hudScript.updateLivesLeft();
                hudScript.updateLivesLost();
            }
            else if(effects[i].ToString().Equals(MoraleEffect.ToString))
            {
                hudScript.updateMoraleText();
            }
        }
    }

    private void checkForInput()
    {
        int nextEventNum = -1;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            nextEventNum = currentEvent.getEvOptions()[0].getJumpsToEventNum();
            Debug.Log("1");

            currentEvent.fireOption(0);
            updateValuesInHUD(currentEvent.getEvOptions()[0].getOptionEffects());
        }

        if(eventOptionsLength > 1 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            nextEventNum = currentEvent.getEvOptions()[1].getJumpsToEventNum();
            Debug.Log("2");

            currentEvent.fireOption(1);
            updateValuesInHUD(currentEvent.getEvOptions()[1].getOptionEffects());
        }

        if(eventOptionsLength > 2 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            nextEventNum = currentEvent.getEvOptions()[2].getJumpsToEventNum();
            Debug.Log("3");

            currentEvent.fireOption(2);
            updateValuesInHUD(currentEvent.getEvOptions()[2].getOptionEffects());
        }

        if(nextEventNum == -3)
        {
            isDoingFinalSpeech = true;
        }

        if(nextEventNum == -2)
        {
            eventIsOpen = false;
            hudScript.flipHUDVis();
            eventObject.SetActive(false);
            return;
        }

        if (nextEventNum != -1)
        {
            currentEvent = eventHandler.grabEvent(nextEventNum);
            displayEvent(currentEvent);
        }
    }

    private void Start()
    {
        eventHandler = GameObject.Find("GameEventSystem").GetComponent<EventHandler>();
        eventObject = GameObject.Find("Event");
        eventTitle = GameObject.Find("Title").GetComponent<Text>();
        eventDescription = GameObject.Find("Description").GetComponent<Text>();
        eventOptions = GameObject.Find("Options").GetComponent<Text>();
        textScrollScript = GameObject.Find("ResourceGain").GetComponent<TextScroll>();
        hudScript = gameObject.GetComponent<HUD>();
        startTime = Time.time;
        secBetweenEventsStore = secBetweenEvents;
        secBetweenRGainStore = secBetweenRGain;
        eventObject.SetActive(false);
        eventIsOpen = false;
        isDoingFinalSpeech = false;
        shownFirstEvent = false;
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
            secBetweenEvents -= Time.deltaTime;
            secBetweenRGain -= Time.deltaTime;

            if(!shownFirstEvent)
            {
                fireEvent();
            }

            if (secBetweenEvents < 0)
            {
                fireEvent();
                secBetweenEvents = secBetweenEventsStore;
            }

            if(secBetweenRGain < 0)
            {
                addPower();
                secBetweenRGain = secBetweenRGainStore;
            }
        }
	}
}
