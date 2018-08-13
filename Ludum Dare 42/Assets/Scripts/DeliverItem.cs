using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverItem : MonoBehaviour {

    private Hero heroScript;
    [SerializeField]
    private float deliveryCooldown;
    private float deliveryCooldownStore;

    private void sendItemAway(GameObject item)
    {
        heroScript.receiveItem(item);
        item.SetActive(false);
        deliveryCooldown = deliveryCooldownStore;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!Input.GetMouseButton(0) && deliveryCooldown <= 0)
        {
            sendItemAway(collision.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        heroScript = GameObject.Find("Hero").GetComponent<Hero>();
        deliveryCooldownStore = deliveryCooldown;
        deliveryCooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(deliveryCooldown > 0)
        {
            deliveryCooldown -= Time.deltaTime;
        }
	}
}
