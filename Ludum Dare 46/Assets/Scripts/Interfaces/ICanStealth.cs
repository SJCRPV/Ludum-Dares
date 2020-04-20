using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanStealth
{
    bool IsInStealth { get; set; }
    int STEALTH { get; }
    void EnterStealth();
    void ExitStealth();

}
