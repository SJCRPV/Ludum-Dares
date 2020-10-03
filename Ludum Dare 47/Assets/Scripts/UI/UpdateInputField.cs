using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInputField : MonoBehaviour
{
    [SerializeField]
    private int maxAllowedValue = 5;
    [SerializeField]
    private int currentNumber = 1;
    [SerializeField]
    private Text inputFieldText;

    public void IncrementNumber()
    {
        currentNumber++;
        if (currentNumber > maxAllowedValue)
        {
            currentNumber = 1;
        }
        inputFieldText.text = currentNumber.ToString();
    }

    public void DecrementNumber()
    {
        currentNumber--;
        if (currentNumber <= 0)
        {
            currentNumber = maxAllowedValue;
        }
        inputFieldText.text = currentNumber.ToString();
    }
}
