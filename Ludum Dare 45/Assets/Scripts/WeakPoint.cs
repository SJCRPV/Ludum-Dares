using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<CharacterControls>()) //Basically, if it's not the player
        {
            if(spriteRenderer == null)
            {
                Destroy(collision.gameObject);
            }
            else if(spriteRenderer.color == collision.GetComponent<SpriteRenderer>().color)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
