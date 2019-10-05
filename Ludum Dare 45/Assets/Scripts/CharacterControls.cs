using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    private enum Directions
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3,
        NONE = 4
    }
    private Vector3 characterMoveVector;
    private bool IsBeingControlled;
    private bool isCarryingBlock;
    private Directions currentDirection;
    private SpriteRenderer currHoldingBlock;
    private Image uiBlockImage;
    [SerializeField]
    private float inputDelay;
    private float inputDelayStore;
    
    private void removeHightlightOfCharacter()
    {
        
    }

    public void ReleaseControl()
    {
        IsBeingControlled = false;
        removeHightlightOfCharacter();
    }

    private void highlightCharacter()
    {

    }

    public void TakeControl()
    {
        IsBeingControlled = true;
        highlightCharacter();
    }

    private void changeDirection(Directions direction)
    {
        if(direction != Directions.NONE)
        {
            switch (direction)
            {
                case Directions.UP:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Directions.DOWN:
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Directions.LEFT:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Directions.RIGHT:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                default:
                    break;
            }
        }
    }

    private SpriteRenderer isThereBlockAt(Vector3 potentialPos)
    {
        Ray2D ray = new Ray2D(potentialPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);

        return hit.collider == null ? null : hit.collider.GetComponent<SpriteRenderer>();
    }

    private Vector3 getPositionOffset()
    {
        Vector3 posOffset = new Vector3();
        switch (currentDirection)
        {
            case Directions.UP:
                posOffset.y = characterMoveVector.y;
                break;
            case Directions.DOWN:
                posOffset.y = -characterMoveVector.y;
                break;
            case Directions.LEFT:
                posOffset.x = -characterMoveVector.x;
                break;
            case Directions.RIGHT:
                posOffset.x = characterMoveVector.x;
                break;
            case Directions.NONE:
            default:
                Debug.LogError("Apparently, I tried to get the offset at the " + Enum.GetName(typeof(Directions), currentDirection) + " direction");
                break;
        }
        return posOffset;
    }

    private void storeBlock()
    {
        uiBlockImage.color = currHoldingBlock.color;
        currHoldingBlock.transform.localPosition = new Vector3(-9999, -9999);
    }

    private void pickUpBlock()
    {
        Vector3 posOffset = getPositionOffset();

        if (posOffset != Vector3.zero)
        {
            currHoldingBlock = isThereBlockAt(transform.position + posOffset);
            if(currHoldingBlock != null)
            {
                storeBlock();
            }
        }
    }

    private void mergeBlocks()
    {
        Destroy(currHoldingBlock.gameObject);
        currHoldingBlock = null;
        uiBlockImage.color = new Color(0, 0, 0, 0);
        //TODO: Play whatever merge sound you get
    }

    private void dropBlock()
    {
        Vector3 posOffset = getPositionOffset();

        if(posOffset != Vector3.zero)
        {
            SpriteRenderer block = isThereBlockAt(transform.position + posOffset);
            if(block != null)
            {
                if(block.color == currHoldingBlock.color)
                {
                    mergeBlocks();
                }
                else
                {
                    //TODO: Play whatever failed merge sound you get
                }
            }
            else
            {
                currHoldingBlock.transform.localPosition = transform.position + posOffset;
                currHoldingBlock = null;
                uiBlockImage.color = new Color(0, 0, 0, 0);
                //TODO: Play whatever drop sound you get
            }
        }
    }

    private void checkForActions()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterManager.instance.SwapToNextCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currHoldingBlock != null)
            {
                dropBlock();
            }
            else
            {
                pickUpBlock();
            }
        }
    }

    private void checkForMovement()
    {
        Vector3 moveVector = new Vector3();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentDirection = Directions.UP;
            moveVector.y += characterMoveVector.y;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            currentDirection = Directions.DOWN;
            moveVector.y -= characterMoveVector.y;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentDirection = Directions.LEFT;
            moveVector.x -= characterMoveVector.x;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentDirection = Directions.RIGHT;
            moveVector.x += characterMoveVector.x;
        }

        changeDirection(currentDirection);
        if(isThereBlockAt(transform.position + moveVector) == null && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.position = transform.position + moveVector;
        }

    }

    private void checkForKeyPresses()
    {
        if(Input.anyKeyDown || (Input.anyKey && inputDelay <= 0))
        {
            checkForMovement();
            checkForActions();
        }
        else if(Input.anyKey && inputDelay >= 0)
        {
            inputDelay -= Time.deltaTime;
        }
        if(!Input.anyKey)
        {
            inputDelay = inputDelayStore;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        characterMoveVector = GameObject.Find("Grid").GetComponent<Grid>().cellSize;
        characterMoveVector += GameObject.Find("Grid").GetComponent<Grid>().cellGap;
        currentDirection = Directions.UP;
        uiBlockImage = GameObject.Find("BlockImg").GetComponent<Image>();
        inputDelayStore = inputDelay;
    }

    // Update is called once per frame
    void Update()
    {
        checkForKeyPresses();
    }
}
