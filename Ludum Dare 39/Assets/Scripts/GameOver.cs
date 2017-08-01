using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private EventList eventList;
    private MainLoop mainScript;
    private bool isGameOver;

    private void compileGameOverEvent()
    {
        Effect[] evOpEff = new Effect[] { new PowerEffect() };
        int[] evOpNumChange = new int[] { 0 };
        EventOption evOp1 = new EventOption("1. Game Over", evOpEff, evOpNumChange, -2);

        Event nEvent = new Event(
            "Game Over", 
            "Here lies the abandoned colony ship. The cruelty of space was too much for it and its ocupants could not reach their promised land. Maybe someone else will have better luck.", 
            new EventOption[] { evOp1 }, 
            false
            );
        mainScript.displayEvent(nEvent);
    }

    public void showGameOver()
    {
        isGameOver = true;
        compileGameOverEvent();
    }

	// Use this for initialization
	void Start () {
        eventList = GameObject.Find("GameEventSystem").GetComponent<EventList>();
        mainScript = GameObject.Find("Player Colony Ship").GetComponent<MainLoop>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameOver && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Application.Quit();
        }
	}
}
