using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmAffectedByTime
{
    int NumOfStepsBeforeEvent { get; }

    void TriggerTimeBasedEvent();
}
