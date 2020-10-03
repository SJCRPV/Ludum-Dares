using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour, ICanMove, ICanInteract
{
    protected TimeManager TimeManager;
    protected LogManager LogManager;

    private bool waitingForNextInput;
    private bool isHarvesting;

    public void InteractWithCellAt(Vector2Int movementVector)
    {
        Vector2 intendedPosition = new Vector2(transform.position.x + movementVector.x, transform.position.y + movementVector.y);

        RaycastHit2D[] results = new RaycastHit2D[1];
        Physics2D.RaycastNonAlloc(intendedPosition, Vector2.zero, results);
        if (results[0] && results[0].collider.gameObject.GetComponent<ICanBeInteractedWith>() != null)
        {
            results[0].collider.gameObject.GetComponent<ICanBeInteractedWith>().GetInteractedWith();
        }
        waitingForNextInput = false;
    }

    private void checkForAdditionalInput()
    {
        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");
        Vector2Int movementVector = Vector2Int.zero;

        if(horizontalMov != 0)
        {
            movementVector.x = horizontalMov < 0 ? -1 : 1;
        }
        else if (verticalMov != 0)
        {
            movementVector.y = verticalMov < 0 ? -1 : 1;
        }

        InteractWithCellAt(movementVector);
    }

    public void MoveCharacter(Vector2Int movementVector)
    {
        Vector2 newPos = new Vector3(transform.position.x + movementVector.x, transform.position.y + movementVector.y, transform.position.z);

        if (Physics2D.Raycast(newPos, Vector2.zero).collider == null)
        {
            transform.position = newPos;
        }
    }

    private void checkForContextlessInput()
    {
        TimeManager.PassTime(1);
        Vector2Int movementVector = Vector2Int.zero;

        if (Input.GetAxis("Horizontal") != 0)
        {
            movementVector.x = Input.GetAxis("Horizontal") < 0 ? -1 : Input.GetAxis("Horizontal") > 0 ? 1 : 0;
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            movementVector.y = Input.GetAxis("Vertical") < 0 ? -1 : Input.GetAxis("Vertical") > 0 ? 1 : 0;
        }
        else if (Input.GetAxis("Interact") != 0)
        {
            waitingForNextInput = true;
            LogManager.LogMessage("Which direction do you want to interact in?");
        }

        if(movementVector != Vector2Int.zero)
        {
            MoveCharacter(movementVector);
        }
    }

    private void checkForPlayerInput()
    {
        if(waitingForNextInput)
        {
            checkForAdditionalInput();
        }
        else
        {
            checkForContextlessInput();
        }
    }

    private void Start()
    {
        LogManager = GetComponent<LogManager>();
        TimeManager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            checkForPlayerInput();
        }
    }
}
