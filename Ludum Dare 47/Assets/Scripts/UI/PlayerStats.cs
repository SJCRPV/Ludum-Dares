using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void PlayerLostEvent();

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Text playerName = null;
    [SerializeField]
    private Image separatorColour = null;
    [SerializeField]
    private Text hpLeftLabel = null;
    [SerializeField]
    private int hpLeft = 7;
    [SerializeField]
    private Text robotsLeftLabel = null;
    [SerializeField]
    private int robotsLeft = 3;
    [SerializeField]
    private Transform lifePointsContainer = null;

    public event PlayerLostEvent OnPlayerLoss;

    private void deductLife()
    {
        hpLeft--;
        hpLeftLabel.text = hpLeft.ToString();
        if (hpLeft <= 0)
        {
            OnPlayerLoss.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (HealthPoint healthPoint in lifePointsContainer.GetComponentsInChildren<HealthPoint>())
        {
            healthPoint.OnHealthLoss += deductLife;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
