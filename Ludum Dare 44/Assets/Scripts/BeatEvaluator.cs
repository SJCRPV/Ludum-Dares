using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatEvaluator : MonoBehaviour {

    public static BeatEvaluator instance;

    [SerializeField]
    private float maxPerfectDistance;
    public float MaxPerfectDistance { get { return maxPerfectDistance; } }
    [SerializeField]
    private float maxGoodDistance;
    public float MaxGoodDistance { get { return maxGoodDistance; } }
    [SerializeField]
    private float maxOkDistance;
    public float MaxOkDistance { get { return maxOkDistance; } }
    [SerializeField]
    private float maxFailureDistance;
    public float MaxFailureDistance { get { return maxFailureDistance; } }

    private Text beatTimingText;
    private Text beatAccuracyText;

    private float howCloseWasIt()
    {
        GameObject nextBeat = BeatManager.instance.NextBeat;
        float distance = Vector2.Distance(transform.position, nextBeat.transform.position) - Player.instance.BeatLeniency;
        if (distance < maxPerfectDistance)
        {
            beatTimingText.text = "Perfect!";
            return 1f;
        }
        else if(distance < maxGoodDistance)
        {
            beatTimingText.text = "Good!";
            return .8f;
        }
        else if(distance < maxOkDistance)
        {
            beatTimingText.text = "Ok!";
            return .75f;
        }
        else
        {
            beatTimingText.text = "Miss!";
            return 0.5f;
        }
    }

    public float beatEvaluation(Beat playerBeat, Beat intendedBeat)
    {
        float attackDamage = Player.instance.DefaultDamage;
        bool sameSide = playerBeat.AttacksFromTheLeft == intendedBeat.AttacksFromTheLeft;
        bool sameModifier = playerBeat.AttackModifier == intendedBeat.AttackModifier;
        string accuracyText = "";
        if (sameSide)
        {
            attackDamage += Player.instance.DefaultDamage / 2;
        }
        else
        {
            accuracyText += "Wrong fist!\n";
        }
        if(sameModifier)
        {
            attackDamage += Player.instance.DefaultDamage / 2;
        }
        else
        {
            accuracyText += "Wrong modifier!\n";
        }

        attackDamage *= howCloseWasIt();

        attackDamage *= Player.instance.DamageBonus;
        accuracyText += "Total Damage: " + attackDamage;
        beatAccuracyText.text = accuracyText;

        Destroy(playerBeat.gameObject);
        Destroy(intendedBeat.gameObject);
        BeatManager.instance.moveToNextBeat();
        return attackDamage;
    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        beatTimingText = GameObject.Find("BeatTiming").GetComponent<Text>();
        beatAccuracyText = GameObject.Find("BeatAccuracy").GetComponent<Text>();
    }
}
