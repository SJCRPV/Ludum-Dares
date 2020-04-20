using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmissionDirection
{
    NORTH,
    NORTHEAST,
    EAST,
    SOUTHEAST,
    SOUTH,
    SOUTHWEST,
    WEST,
    NORTHWEST,
    ALL
}

public interface IEmmitLight
{
    int EmmissionDistance { get; }
    EmissionDirection EmissionDirection { get; }

    void LightenTheArea();
    void ChangeEmissionDirection(EmissionDirection newDirection);
}
