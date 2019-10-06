using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField]
    private float cameraFollowSpeed = 2;
    private CharacterControls characterToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(characterToFollow == null || !characterToFollow.IsBeingControlled)
        {
            characterToFollow = CharacterManager.instance.charactersList.Select(x => x.GetComponent<CharacterControls>()).Where(x => x.IsBeingControlled).FirstOrDefault();
        }

        if(characterToFollow != null)
        {
            Vector3 newPos = characterToFollow.transform.position;
            newPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, newPos, cameraFollowSpeed * Time.deltaTime);
        }
    }
}
