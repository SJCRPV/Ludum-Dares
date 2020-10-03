using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public List<IAmAffectedByTime> TimeSensitiveObjects { get; } = new List<IAmAffectedByTime>();

    [SerializeField]
    private int stepCounter = 0;
    public int StepCounter => stepCounter;

    public void PassTime(int numberOfSteps, Action callback = null)
    {
        stepCounter += numberOfSteps;

        foreach (IAmAffectedByTime obj in TimeSensitiveObjects)
        {
            if(stepCounter % obj.NumOfStepsBeforeEvent == 0)
            {
                obj.TriggerTimeBasedEvent();
            }
        }
        callback?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
