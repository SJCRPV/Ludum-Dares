using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveHealth
{
    int Health { get; }
    int MaxHealth { get; set; }
    void AlterHealth(int change);
}
