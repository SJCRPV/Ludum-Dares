using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

//FIX: Can't inherit from RigidbodyFirstPersonController
public class SpawnPixels : RigidbodyFirstPersonController
{

    public GameObject pixelToSpawn;

    [SerializeField]
    private float timeBetweenPixelSpawn;

    private Vector3 pixelSpawnPosition;
    private Quaternion playerRotation;
    private float startingYCoor;

    private IEnumerator spawnPixels()
    {
        Instantiate(pixelToSpawn, pixelSpawnPosition - new Vector3(0.2f, 0, 0), playerRotation);
        Instantiate(pixelToSpawn, pixelSpawnPosition + new Vector3(0.2f, 0, 0), playerRotation);
        yield return new WaitForSeconds(timeBetweenPixelSpawn);
    }

    private void Start()
    {
        startingYCoor = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        //TODO: Allow the player to simply walk around if he's up high instead of having to press Q every second to keep the altitude. Only come down if he jumps
	    if(Input.GetButton("SpawnPixel"))
        {
            pixelSpawnPosition = transform.position + (transform.forward / 4);
            pixelSpawnPosition.y -= gameObject.GetComponent<CapsuleCollider>().height / 1.75f;
            playerRotation = gameObject.transform.rotation;

            if ((Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Vertical") == 1) || !Grounded)
            {
                StartCoroutine("spawnPixels");
            }
        }
    }
}
