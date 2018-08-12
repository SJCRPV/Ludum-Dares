using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : World {

    public static List<Item> inventory;
    public static List<Item> swapQueue;

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

    public Item fetchNearestPotion()
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].IsConsumable && inventory[i].ItemElement == (int)Elements.Normal)
            {
                return inventory[i];
            }
        }
        return null;
    }

	// Use this for initialization
	void Start () {
        inventory = new List<Item>();
        swapQueue = new List<Item>();
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
