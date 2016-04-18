using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayDisguiseTimeLeft : MonoBehaviour {

    private GameObject player;
    private SnatchCitizen snatchCitizenScript;
    private Text text;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        snatchCitizenScript = player.GetComponent<SnatchCitizen>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0, 2, 0));
        if(snatchCitizenScript.getTimeBeforeKill() == -1)
        {
            text.text = "He knows who you are. Find a body to snatch and then follow the arrow!";
        }
        else if(snatchCitizenScript.getTimeBeforeKill() == -2)
        {
            text.text = "You missed. Try getting closer to the person.";
        }
        else if(snatchCitizenScript.getTimeBeforeKill() == -3)
        {
            text.text = "That citizen was already snatched.";
        }
        else if (snatchCitizenScript.getTimeBeforeKill() < 15)
        {
            text.text = "Time until body is found: " + snatchCitizenScript.getTimeBeforeKill().ToString();
        }
        else
        {
            text.text = "Body found! He knows...";
        }
	}
}
