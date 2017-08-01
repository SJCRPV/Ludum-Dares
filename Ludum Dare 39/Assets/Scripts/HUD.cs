using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private GameObject HUDObj;
    private Button warpBtn;
    private Button fSpeechBtn;
    private Text powerLeftTxt;
    private Text livesLeftTxt;
    private Text livesLostTxt;
    private Text moraleTxt;
    private Text jumpsLeftTxt;
    private Text jumpsMadeTxt;

    public void setHUDVis(bool newState)
    {
        HUDObj.SetActive(newState);
    }
    public void updatePower()
    {
        powerLeftTxt.text = "Power Left: " + PowerEffect.staticGetVarValue();
    }
    public void updateLivesLeft()
    {
        livesLeftTxt.text = "Lives Left: " + LivesEffect.staticGetLivesRemaining();
    }
    public void updateLivesLost()
    {
        livesLostTxt.text = "Lives Lost: " + LivesEffect.staticGetLivesLost();
    }
    public void updateMoraleText()
    {
        moraleTxt.text = "Current Morale: " + MoraleEffect.staticGetMoraleValue();
    }
    public void updateJumpsLeft()
    {
        jumpsLeftTxt.text = "Jumps until destination (estimate): " + WarpEffect.JumpsLeft;
    }
    public void updateJumpsMade()
    {
        jumpsMadeTxt.text = "Jumps already made: " + WarpEffect.JumpsMade;
    }

    private void setDefaultValues()
    {
        powerLeftTxt.text = "Power Left: " + PowerEffect.staticGetVarValue();
        livesLeftTxt.text = "Lives Left: " + LivesEffect.staticGetLivesRemaining();
        livesLostTxt.text = "Lives Lost: " + LivesEffect.staticGetLivesLost();
        //TODO: Morale number interpreter
        moraleTxt.text = "Current Morale: " + MoraleEffect.staticGetMoraleValue();
        jumpsLeftTxt.text = "Jumps until destination (estimate): " + WarpEffect.JumpsLeft;
        jumpsMadeTxt.text = "Jumps already made: " + WarpEffect.JumpsMade;
    }

    // Use this for initialization
    void Start()
    {
        HUDObj = GameObject.Find("HUD");
        warpBtn = GameObject.Find("WarpBtn").GetComponent<Button>();
        fSpeechBtn = GameObject.Find("FinalSpeechBtn").GetComponent<Button>();
        powerLeftTxt = GameObject.Find("PowerLeft").GetComponent<Text>();
        livesLeftTxt = GameObject.Find("LivesLeft").GetComponent<Text>();
        livesLostTxt = GameObject.Find("LivesLost").GetComponent<Text>();
        moraleTxt = GameObject.Find("Morale").GetComponent<Text>();
        jumpsLeftTxt = GameObject.Find("JumpsLeft").GetComponent<Text>();
        jumpsMadeTxt = GameObject.Find("JumpsMade").GetComponent<Text>();

        setDefaultValues();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
