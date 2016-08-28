using UnityEngine;
using System.Collections;

public class openDialogue : MonoBehaviour {

    [SerializeField]
    private Sprite sChecked;

    private Rigidbody2D rigidBody;
    private Transform dialogueBox;
    private SpriteRenderer spriteRen;

    public void openDialogueBox()
    {
        spriteRen.sprite = sChecked;
        dialogueBox.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        dialogueBox.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
        dialogueBox = this.transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
