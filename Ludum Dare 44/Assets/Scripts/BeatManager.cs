using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour {

    public static BeatManager instance;

    [SerializeField]
    private int beatsPerMinute = 60;
    [SerializeField]
    private bool isDroppingBeats = true;
    [SerializeField]
    private double timeBetweenBeats;
    private double timeBetweenBeatsStore;

    public bool IsDroppingBeats { get { return isDroppingBeats; } set { isDroppingBeats = value; } }
    public GameObject NextBeat { get; private set; }

    private Text beatTimingText;
    private GameObject beatEvaluatorObj;

    private void calcTimeBetweenBeats()
    {
        timeBetweenBeats = (60f / beatsPerMinute);
        timeBetweenBeatsStore = timeBetweenBeats;
    }

    private void OnValidate()
    {
        calcTimeBetweenBeats();
    }

    public void moveToNextBeat()
    {
        int siblingIndex = NextBeat.transform.GetSiblingIndex();
        NextBeat = NextBeat.transform.parent.GetChild(siblingIndex + 1).gameObject;
    }

    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        calcTimeBetweenBeats();
        beatEvaluatorObj = GameObject.Find("Centre");
        NextBeat = GameObject.Find("BeatQueue").transform.GetChild(0).gameObject;
        beatTimingText = GameObject.Find("BeatTiming").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isDroppingBeats)
        {
            timeBetweenBeats -= Time.deltaTime;
        }

        if(timeBetweenBeats <= 0)
        {
            BeatConstructor.instance.makeRandomBeat();
            timeBetweenBeats = timeBetweenBeatsStore;
        }

        if(NextBeat.transform.position.x >= beatEvaluatorObj.transform.position.x + BeatEvaluator.instance.MaxFailureDistance)
        {
            beatTimingText.text = "Miss!";
            moveToNextBeat();
        }
	}
}
