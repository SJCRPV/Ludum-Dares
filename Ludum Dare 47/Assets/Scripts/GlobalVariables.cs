using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public bool IsPaused { get; set; }
    public int TimeMultiplier { get; set; } = 1;
    public int NumberOfRows { get; } = 22;
    public int NumberOfRobotsPerPlayer { get; } = 3;

    public float TimeIncrement 
    { 
        get 
        {
            return IsPaused ? 0f : Time.deltaTime * TimeMultiplier;
        } 
    }
}
