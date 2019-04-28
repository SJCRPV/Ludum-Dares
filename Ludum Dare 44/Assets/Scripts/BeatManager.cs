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
    public bool IsDroppingBeats { get { return isDroppingBeats; } set { isDroppingBeats = value; } }
    [SerializeField]
    private double timeBetweenBeats;
    private double timeBetweenBeatsStore;

    public GameObject NextBeat { get; private set; }

    private Text beatTimingText;
    private GameObject beatEvaluatorObj;
    private Transform beatQueueTransform;

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
        try
        {
            int siblingIndex = NextBeat.transform.GetSiblingIndex();
            NextBeat = NextBeat.transform.parent.GetChild(siblingIndex + 1).gameObject;
        }
        catch
        {
            //Assuming that you just came out of the godly interaction screen, the NextBeat should be the one on sibling index 0
            NextBeat = beatQueueTransform.GetChild(0).gameObject;
        }
        
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
        beatQueueTransform = GameObject.Find("BeatQueue").transform;
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

        if(!InteractionWithGod.instance.IsInteractingWithGod && NextBeat.transform.position.x >= beatEvaluatorObj.transform.position.x + BeatEvaluator.instance.MaxFailureDistance)
        {
            beatTimingText.text = "Miss!";
            moveToNextBeat();
        }

        if(beatQueueTransform.childCount > 0 && InteractionWithGod.instance.IsInteractingWithGod)
        {
            List<GameObject> temp = new List<GameObject>();
            foreach(Transform child in beatQueueTransform)
            {
                temp.Add(child.gameObject);
            }
            temp.ForEach(child => Destroy(child));
        }
	}
}
