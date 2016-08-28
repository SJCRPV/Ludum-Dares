using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerInteraction : MonoBehaviour {

    [SerializeField]
    private float unitsPerPress;
    [SerializeField]
    private float quickMovementCountdown;

    private bool foundLauncher;
    private bool foundCrossbow;
    private bool foundGat;
    private bool foundShotgun;

    private bool gWasPressed;
    private bool eWasPressed;
    private Text logTextScript;
    private Vector3 pos;
    private bool hasMoved = false;
    private bool hasLauncher = false;
    private bool hasCrossbow = false;
    private bool hasGat = false;
    private bool hasShotgun = false;
    private float quickMovementCountdownStore;

    public void setHasLauncher()
    {
        hasLauncher = true;
    }
    public void setHasCrossbow()
    {
        hasCrossbow = true;
    }
    public void setHasGat()
    {
        hasGat = true;
    }
    public void setHasShotgun()
    {
        hasShotgun = true;
    }

    private Collider2D[] isAnythingThereCol(Vector2 intendedPos)
    {
        Collider2D[] temp = Physics2D.OverlapAreaAll(new Vector2(intendedPos.x - 0.25f, intendedPos.y - 0.25f), new Vector2(intendedPos.x + 0.25f, intendedPos.y + 0.25f));

        for (int i = 0; i < temp.Length; i++)
        {
            Debug.Log(temp[i]);
        }

        return temp;
    }

    private bool isAnythingThere(Vector2 intendedPos)
    {
        Collider2D[] temp = Physics2D.OverlapAreaAll(new Vector2(intendedPos.x - 0.25f, intendedPos.y - 0.25f), new Vector2(intendedPos.x + 0.25f, intendedPos.y + 0.25f));

        for (int i = 0; i < temp.Length; i++)
        {
            Debug.Log(temp[i]);
        }

        if (temp.Length <= 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private Vector3 updatePos(Vector2 posToUpdate)
    {
        pos = posToUpdate;

        if (!hasMoved)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if(!isAnythingThere(new Vector2(pos.x + unitsPerPress, pos.y)) || eWasPressed == true)
                {
                    pos.x += unitsPerPress;
                }
                else
                {
                    Debug.Log("Tried to go out of bounds: Right!");
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (!isAnythingThere(new Vector2(pos.x - unitsPerPress, pos.y)) || eWasPressed == true)
                {
                    pos.x -= unitsPerPress;
                }
                else
                {
                    Debug.Log("Tried to go out of bounds: Left!");
                }
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                if (!isAnythingThere(new Vector2(pos.x, pos.y + unitsPerPress)) || eWasPressed == true)
                {
                    pos.y += unitsPerPress;
                }
                else
                {
                    Debug.Log("Tried to go out of bounds: Up!");
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                if (!isAnythingThere(new Vector2(pos.x, pos.y - unitsPerPress)) || eWasPressed == true)
                {
                    pos.y -= unitsPerPress;
                }
                else
                {
                    Debug.Log("Tried to go out of bounds: Down!");
                }
            }

            hasMoved = true;
        }

        if (hasMoved)
        {
            Mathf.RoundToInt(pos.x);
            Mathf.RoundToInt(pos.y);
        }
        return pos;
    }

    private void conclusionToG()
    {
        if(isAnythingThere(transform.position))
        {
            Collider2D[] temp = isAnythingThereCol(transform.position);
            Debug.Log("temp[1].name " + temp[1].name);
            if(temp[1].name == "Launcher")
            {
                if(!foundLauncher)
                {
                    logTextScript.text = "This device looks like a launcher of some kind.\nWith no better idea, you decide to call it that.";
                    foundLauncher = true;
                }
                else
                {
                    logTextScript.text = "You pick up a Launcher from the ground.";
                }
            }
            else if(temp[1].name == "Crossbow")
            {
                if(!foundCrossbow)
                {
                    logTextScript.text = "Considerably more advanced than anything you've seen,\nbut it looks like a crossbow of some kind. With an internal shrug, you decide to call it that.";
                    foundCrossbow = true;
                }
                else
                {
                    logTextScript.text = "You pick up a Crossbow from the ground.";
                }
            }
            else if(temp[1].name == "Gat")
            {
                if(!foundGat)
                {
                    logTextScript.text = "Amidst all the glowing and beeps, the closest thing you can resemble it to would be a gatling gun.\nFor convenience, you decided to just call it Gat.";
                    foundGat = true;
                }
                else
                {
                    logTextScript.text = "You pick up a Gat from the ground.";
                }
            }
            else if(temp[1].name == "Shotgun")
            {
                if(!foundShotgun)
                {
                    logTextScript.text = "You have no idea what exactly this fires, but by the kick it gives, it's pretty much a shotgun.\nAnd you call it so.";
                    foundShotgun = true;
                }
                else
                {
                    logTextScript.text = "You pick up a Shotgun from the ground.";
                }
            }
        }
        else
        {
            logTextScript.text = "There's nothing on the ground to pick up.";
        }
    }

    private void conclusionToE()
    {
        Vector2 tempVector = transform.position;
        if (Input.anyKeyDown)
        {
            tempVector = updatePos(tempVector);
            eWasPressed = false;
        }

        if (isAnythingThere(tempVector))
        {
            Collider2D[] temp = isAnythingThereCol(tempVector);
            if (temp[1].name == "Computer")
            {
                temp[1].gameObject.GetComponent<openDialogue>().openDialogueBox();
            }
        }
    }

    private void checkActivity()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            quickMovementCountdown -= Time.deltaTime;
            if (quickMovementCountdown <= 0)
            {
                hasMoved = false;
            }
            transform.position = updatePos(transform.position);
        }
        else
        {
            quickMovementCountdown = quickMovementCountdownStore;
            hasMoved = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            logTextScript.text = "Which direction do you want to interact in?\n(Press an arrow key. Anything else to cancel)";
            eWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            conclusionToG();
        }
    }

	// Use this for initialization
	void Start () {
        quickMovementCountdownStore = quickMovementCountdown;
        logTextScript = GameObject.Find("Log").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (eWasPressed)
        {
            conclusionToE();
        }
        else
        {
            checkActivity();
        }
	}
}
