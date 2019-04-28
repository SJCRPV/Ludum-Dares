using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatConstructor : MonoBehaviour {

    public static BeatConstructor instance;

    [SerializeField]
    private GameObject beatPrefab;

    private Transform beatQueue;

    public bool UpModifier { get; set; }
    public bool RightModifier { get; set; }
    public bool DownModifier { get; set; }
    public bool LeftModifier { get; set; }
    public bool IsAttackingFromLeft { get; set; }
    public bool IsAttackingFromRight { get; set; }

    public float attack(bool isFromTheLeft)
    {
        int modifier = -1;
        if (UpModifier) { modifier = (int)Beat.AttackModifiers.UP; }
        else if (RightModifier) { modifier = (int)Beat.AttackModifiers.RIGHT; }
        else if (DownModifier) { modifier = (int)Beat.AttackModifiers.DOWN; }
        else if (LeftModifier) { modifier = (int)Beat.AttackModifiers.LEFT; }

        GameObject gObj = Instantiate(beatPrefab);
        Beat playerBeat = gObj.GetComponent<Beat>();
        playerBeat.ControlledInit(isFromTheLeft, modifier);
        Beat intendedBeat = BeatManager.instance.NextBeat.GetComponent<Beat>();

        return BeatEvaluator.instance.beatEvaluation(playerBeat, intendedBeat);
    }

    public void makeRandomBeat()
    {
        GameObject gObj = Instantiate(beatPrefab, beatQueue, false);
        gObj.GetComponent<Beat>().RandomInit();
    }

    // Use this for initialization
    void Start ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        beatQueue = GameObject.Find("BeatQueue").transform;
        makeRandomBeat();
	}
}
