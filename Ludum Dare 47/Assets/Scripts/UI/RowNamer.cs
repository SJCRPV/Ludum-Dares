using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowNamer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int counter = 1;
        foreach (Text text in GetComponentsInChildren<Text>())
        {
            text.text = counter.ToString();
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
