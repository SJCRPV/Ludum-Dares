using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverItem : MonoBehaviour {

    Hero heroScript;

    private void sendItemAway(Item item)
    {
        heroScript.receiveItem(item);
        Destroy(item);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!Input.GetMouseButton(0))
        {
            sendItemAway(collision.gameObject.GetComponent<Item>());
        }
    }
    // Use this for initialization
    void Start () {
        heroScript = GameObject.Find("Hero").GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
