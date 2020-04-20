using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    [SerializeField]
    private Text logWindow;

    public void LogMessage(string message)
    {
        if(logWindow.text.Split('\n').Length > 15)
        {
            int endOfLineIndex = logWindow.text.IndexOf('\n', 1);
            logWindow.text = logWindow.text.Remove(0, endOfLineIndex);
        }
        logWindow.text += $"\n{message}";
    }

    private void Start()
    {
        logWindow.text = "";
    }
}
