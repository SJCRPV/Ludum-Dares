using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : World {

    public static List<GameObject> inventory;
    public static List<GameObject> swapQueue;

    [SerializeField]
    private float timeBetweenQueueItems;
    private float timeBetweenQueueItemsStore;
    private bool queueIsBeingProcessed;

    private IEnumerator dealWithQueue()
    {
        timeBetweenQueueItems = timeBetweenQueueItemsStore;

        while(swapQueue.Count > 0)
        {
            while (timeBetweenQueueItems > 0)
            {
                timeBetweenQueueItems -= Time.deltaTime;
                yield return null;
            }
            timeBetweenQueueItems = timeBetweenQueueItemsStore;
            Instantiate(swapQueue[0]);
            swapQueue.RemoveAt(0);
        }
        queueIsBeingProcessed = false;
        StopCoroutine("dealWithQueue");
    }

    public GameObject fetchNearestPotion()
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            Consumable potentialPotion = inventory[i].GetComponent<Consumable>();
            if (potentialPotion.IsConsumable && potentialPotion.ItemElement == (int)Elements.Normal)
            {
                return inventory[i];
            }
        }
        return null;
    }

	// Use this for initialization
	void Start () {
        inventory = new List<GameObject>();
        swapQueue = new List<GameObject>();
        timeBetweenQueueItemsStore = timeBetweenQueueItems;
        queueIsBeingProcessed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(swapQueue.Count > 0 && !queueIsBeingProcessed)
        {
            queueIsBeingProcessed = true;
            StartCoroutine("dealWithQueue");
        }

	}
}
