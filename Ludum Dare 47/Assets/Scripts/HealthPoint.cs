using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HealthPointLostEvent();

public class HealthPoint : MonoBehaviour
{
    public event HealthPointLostEvent OnHealthLoss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHealthLoss?.Invoke();
    }
}
