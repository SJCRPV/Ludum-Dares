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
    private GameObject winText;
    private TextScroll textScrollScript;
    private FinalSpeech finalSpeechScript;
    private GameObject fSpeechUI;
    private Warp warpScript;
    private GameOver gameOverScript;
    [SerializeField]
    private int costPerJump;
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

    public void displayEvent(Event nEvent)
    {
        hudScript.setHUDVis(false);
        eventIsOpen = true;
        eventObject.SetActive(true);
        eventTitle.text = nEvent.getTitle();
        eventDescription.text = nEvent.getEvDescription();
        eventOptions.text = nEvent.getEvOptionsString();
    }

    private void fireEvent()
    {
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

    private void resetTimers()
    {
        secBetweenEvents = secBetweenEventsStore;
        secBetweenRGain = secBetweenRGainStore;
    }

    IEnumerator delayedFireEvent()
    {
        Debug.Log("Hai" + warpScript.getFullAnimsLength());
        yield return new WaitForSeconds(warpScript.getFullAnimsLength());
        fireEvent();
        StopCoroutine("delayedFireEvent");
    }

    private void updateValuesInHUD(Effect[] effects)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i].ToString().Equals(PowerEffect.ToString))
            {
                hudScript.updatePower();
            }
            else if (effects[i].ToString().Equals(LivesEffect.ToString))
            {
                hudScript.updateLivesLeft();
                hudScript.updateLivesLost();
            }
            else if (effects[i].ToString().Equals(MoraleEffect.ToString))
            {
                hudScript.updateMoraleText();
            }
            else if (effects[i].ToString().Equals(WarpEffect.ToString))
            {
                hudScript.updateJumpsMade();
                hudScript.updateJumpsLeft();
            }
        }
    }

    public void playWarpAnims()
    {
        StartCoroutine("delayedFireEvent");
        PowerEffect.staticChangeVarValue(costPerJump);
        WarpEffect.changeValuesByOne();
        updateValuesInHUD(new Effect[] { new PowerEffect(), new WarpEffect() });
        warpScript.playWarp();
        resetTimers();
    }

    public void fSpeechButtonPressed()
    {
        currentEvent = eventHandler.grabEvent(eventHandler.ListSize - 1);
        eventOptionsLength = currentEvent.getEvOptions().Length;
        Debug.Log("Final Speech!");
        displayEvent(currentEvent);
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
            finalSpeechScript.confirmFinalEvent();
            fSpeechUI.SetActive(true);
            return;
        }

        if(nextEventNum == -2)
        {
            eventIsOpen = false;
            hudScript.setHUDVis(true);
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
        finalSpeechScript = GameObject.Find("Player Colony Ship").GetComponent<FinalSpeech>();
        fSpeechUI = GameObject.Find("FinalSpeechUI");
        winText = GameObject.Find("WinText");
        winText.SetActive(false);
        gameOverScript = gameObject.GetComponent<GameOver>();
        warpScript = gameObject.GetComponent<Warp>();
        hudScript = gameObject.GetComponent<HUD>();

        startTime = Time.time;
        secBetweenEventsStore = secBetweenEvents;
        secBetweenRGainStore = secBetweenRGain;
        costPerJump *= -1;

        fSpeechUI.SetActive(false);
        eventObject.SetActive(false);

        eventIsOpen = false;
        isDoingFinalSpeech = false;
        shownFirstEvent = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if(PowerEffect.staticGetVarValue() <= 0 || MoraleEffect.staticGetMoraleValue() <= 0 || LivesEffect.staticGetLivesRemaining() <= 0)
        {
            gameOverScript.showGameOver();
        }

        if(WarpEffect.JumpsLeft <= 0)
        {
            winText.SetActive(true);
        }

        if (!finalSpeechScript.isFinalEventConfirmed())
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

                if (!shownFirstEvent)
                {
                    fireEvent();
                }

                if (secBetweenEvents < 0)
                {
                    fireEvent();
                    secBetweenEvents = secBetweenEventsStore;
                }

                if (secBetweenRGain < 0)
                {
                    addPower();
                    secBetweenRGain = secBetweenRGainStore;
                }
            }
        }
	}
}
