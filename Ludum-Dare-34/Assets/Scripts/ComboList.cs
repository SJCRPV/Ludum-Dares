using UnityEngine;
using System.Collections;

public class ComboList : MonoBehaviour {

    private int moveToExecute;

    enum combinations
    {
        DEFAULT,
        PIERCING_KICK,
        SIMPLE_LAUNCHER,
        COMPLETE_LAUNCHER,
        THROW,
        BACK_SPIN_KICK,
        AIR_DEFAULT,
        AIR_DIAGONAL,
        AIR_THROW,
        AIR_SPIN_KICK
    }

    public void checkIfCombo(KeyCode[] lastKeysPressed, bool isJumping)
    {
        //Ground combos
        if (!isJumping)
        {
            if (lastKeysPressed[4] == KeyCode.A && lastKeysPressed[3] == KeyCode.S && lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Default combo
                moveToExecute = (int)combinations.DEFAULT;
            }
            else if (lastKeysPressed[3] == KeyCode.A && lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.S && lastKeysPressed[0] == KeyCode.S)
            {
                //Piercing kick
                moveToExecute = (int)combinations.PIERCING_KICK;
            }
            else if (lastKeysPressed[2] == KeyCode.A && lastKeysPressed[1] == KeyCode.S && lastKeysPressed[0] == KeyCode.S)
            {
                //Simple Launcher
                moveToExecute = (int)combinations.SIMPLE_LAUNCHER;
            }
            else if (lastKeysPressed[3] == KeyCode.A && lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.S && lastKeysPressed[0] == KeyCode.A)
            {
                //Complete Launcher
                moveToExecute = (int)combinations.COMPLETE_LAUNCHER;
            }
            else if (lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Throw attack
                moveToExecute = (int)combinations.THROW;
            }
            else if (lastKeysPressed[2] == KeyCode.A && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Back-Handed Spin Kick
                moveToExecute = (int)combinations.BACK_SPIN_KICK;
            }
        }
        else
        {
            if (lastKeysPressed[4] == KeyCode.A && lastKeysPressed[3] == KeyCode.S && lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Default Air combo
                moveToExecute = (int)combinations.AIR_DEFAULT;
            }
            else if (lastKeysPressed[3] == KeyCode.A && lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.S && lastKeysPressed[0] == KeyCode.S)
            {
                //Diagonal Air kick
                moveToExecute = (int)combinations.AIR_DIAGONAL;
            }
            else if (lastKeysPressed[2] == KeyCode.S && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Air Throw
                moveToExecute = (int)combinations.AIR_THROW;
            }
            else if (lastKeysPressed[2] == KeyCode.A && lastKeysPressed[1] == KeyCode.A && lastKeysPressed[0] == KeyCode.S)
            {
                //Air Spin Kick
                moveToExecute = (int)combinations.AIR_SPIN_KICK;
            }
        }
        moveToExecute = -1;
        whatToExecute(moveToExecute);
    }

    //GROUND ATTACKS
    public void ExecuteDefault()
    {

    }
    public void ExecutePiercingKick()
    {

    }
    public void ExecuteSimpleLauncher()
    {

    }
    public void ExecuteCompleteLauncher()
    {

    }
    public void ExecuteThrow()
    {

    }
    public void ExecuteBackSpinKick()
    {

    }

    //AIR ATTACKS
    public void ExecuteAirDefault()
    {

    }
    public void ExecuteAirDiagonal()
    {

    }
    public void ExecuteAirThrow()
    {

    }
    public void ExecuteAirSpinKick()
    {

    }

    public void whatToExecute(int moveToExecute)
    {
        switch (moveToExecute)
        {
            case (int)combinations.DEFAULT:
                ExecuteDefault();
                break;

            case (int)combinations.PIERCING_KICK:
                ExecutePiercingKick();
                break;

            case (int)combinations.SIMPLE_LAUNCHER:
                ExecuteSimpleLauncher();
                break;

            case (int)combinations.COMPLETE_LAUNCHER:
                ExecuteCompleteLauncher();
                break;

            case (int)combinations.THROW:
                ExecuteThrow();
                break;

            case (int)combinations.BACK_SPIN_KICK:
                ExecuteBackSpinKick();
                break;

            case (int)combinations.AIR_DEFAULT:
                ExecuteAirDefault();
                break;

            case (int)combinations.AIR_DIAGONAL:
                ExecuteAirDiagonal();
                break;

            case (int)combinations.AIR_THROW:
                ExecuteAirThrow();
                break;

            case (int)combinations.AIR_SPIN_KICK:
                ExecuteAirSpinKick();
                break;

            default:
                break;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
