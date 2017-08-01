using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    private Animation anims;

    public float getFullAnimsLength()
    {
        Debug.Log(anims.GetClip("WarpOut").length + 1 + anims.GetClip("WarpIn").length);
        return (anims.GetClip("WarpOut").length + 1 + anims.GetClip("WarpIn").length);
    }

    private IEnumerator playWarpAnims()
    {
        anims.Play("WarpOut");
        yield return new WaitForSeconds(anims.GetClip("WarpOut").length);
        yield return new WaitForSeconds(1);
        anims.Play("WarpIn");
        yield return new WaitForSeconds(anims.GetClip("WarpIn").length);
        StopCoroutine("playWarpAnims");
    }

    public void playWarp()
    {
        StartCoroutine("playWarpAnims");
    }

    // Use this for initialization
    void Start()
    {
        anims = gameObject.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
