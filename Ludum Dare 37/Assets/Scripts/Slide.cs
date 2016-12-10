using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

//FIX: Can't inherit from RigidbodyFirstPersonController
public class Slide : RigidbodyFirstPersonController
{
    [SerializeField]
    private float slideBoost;
    [SerializeField]
    private float slideDrag;

    private CapsuleCollider playerCollider;
    private Rigidbody playerRigidbody;

    private IEnumerator slide()
    {
        playerCollider.height = playerCollider.height / 2;
        playerRigidbody.drag = 0f;
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);
        playerRigidbody.AddForce(new Vector3(slideBoost, 0f, 0f), ForceMode.Impulse);

        yield return new WaitForSeconds(1);

        playerRigidbody.drag = slideDrag;

    }

	// Use this for initialization
	void Start () {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Slide"))
        {
            slide();
        }
	}
}
