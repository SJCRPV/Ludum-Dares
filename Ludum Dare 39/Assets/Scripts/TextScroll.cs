using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroll : MonoBehaviour {

    [SerializeField]
    private GameObject resourceGainGObj;
    [SerializeField]
    private float scrollSpeed;
    private float scrollStartTime;
    private Vector3 endPos;
    private Vector3 startPos;
    private float journeyLength;
    private bool scrolling;

    private IEnumerator scrollTextUpwards()
    {
        //resourceGainGObj.transform.position = startPos;
        //scrollStartTime = (DateTime.Now.Hour + (DateTime.Now.Minute * 0.01f));
        //while (resourceGainGObj.transform.position.y < startPos.y + 130)
        //{
        //    //float distCovered = ((DateTime.Now.Hour + (DateTime.Now.Minute * 0.01f)) - scrollStartTime) * scrollSpeed;
        //    //float movSpeed = distCovered / journeyLength;
        //    resourceGainGObj.transform.position = Vector3.Lerp(resourceGainGObj.transform.position, endPos, scrollSpeed);
        //    yield return null;
        //}
        yield return new WaitForSeconds(2);
        StopCoroutine("scrollTextUpwards");
        resourceGainGObj.SetActive(false);
    }

    public void startScrolling()
    {
        resourceGainGObj.SetActive(true);
        StartCoroutine("scrollTextUpwards");
    }

    // Use this for initialization
    void Start () {
        resourceGainGObj = GameObject.Find("ResourceGain");
        //startPos = resourceGainGObj.transform.position;
        //endPos = new Vector3(resourceGainGObj.transform.position.x, resourceGainGObj.transform.position.y + 130);
        //journeyLength = Vector3.Distance(startPos, endPos);
        resourceGainGObj.SetActive(false);
    }
}
