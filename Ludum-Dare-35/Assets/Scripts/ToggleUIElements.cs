using UnityEngine;
using System.Collections;

public class ToggleUIElements : MonoBehaviour {

    public GameObject GUI_Image;

    private Renderer targetVisible;

	// Use this for initialization
	void Start () {
        targetVisible = GameObject.Find("Target").GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (targetVisible != null)
        {
            if (targetVisible.isVisible)
            {
                GUI_Image.SetActive(false);
            }
            else
            {
                GUI_Image.SetActive(true);
            }
        }
	}
}
