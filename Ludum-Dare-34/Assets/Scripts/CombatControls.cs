using UnityEngine;
using System.Collections;

public class CombatControls : MonoBehaviour {

    ComboList comboListScript;

    public float dodgeCooldown;
    public float attackChargeMultiplier;
    public float jumpSpeed;
    public float attackDelay;
    public float comboExecutionDelay;

    Vector2 jumpVector;
    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;
    float dodgeCooldownStore;
    float attackDelayStore;
    float comboExecutionDelayStore;
    bool isAttacking;
    bool isFalling;
    bool isJumping;
    int moveToExecute;
    static KeyCode[] lastKeysPressed;

    void clearArray()
    {
        KeyCode[] newArray = new KeyCode[5];
        lastKeysPressed = newArray;
    }

    void insertIntoArray(KeyCode keyCode)
    {
        Debug.Log("A: " + KeyCode.A);
        for (int i = 0; i < lastKeysPressed.Length - 1; i++)
        {
            lastKeysPressed[i + 1] = lastKeysPressed[i];
        }
        lastKeysPressed[0] = keyCode;
    }
    
    void attack()
    {
        BroadcastMessage("swapColliderStatus");
        isAttacking = true;
        attackDelay = attackDelayStore;
        //Debug.Log("AttackHitbox is on!");
    }

    void dodge()
    {

    }

    void Controls()
    {
        comboExecutionDelay -= Time.unscaledDeltaTime;
        if (Input.GetButton("Attack") && Input.GetButton("Dodge") && isFalling == false)
        {
            if (jumpVector.y >= -0.5f)
            {
                isFalling = true;
                isJumping = true;
                return;
            }
            jump();
        }
        else
        {
            isFalling = true;
            isJumping = true;
            drop();
        }

        if(jumpVector.y <= -2.5f)
        {
            isFalling = false;
            isJumping = false;
        }

        if (Input.GetButton("Dodge") && dodgeCooldown < 0)
        {
            boxCollider.enabled = false;
            dodgeCooldown = dodgeCooldownStore;
            //Debug.Log("Dodge Hitbox is off!");
            return;
        }
        else
        {
            if (dodgeCooldown <= dodgeCooldownStore / 2)
            {
                boxCollider.enabled = true;
                //Debug.Log("Dodge Hitbox is on!");
            }
        }

        if (Input.GetButton("Attack") && attackDelay <= 0)
        {
            attack();
            return;
        }
        else
        {
            if (circleCollider.enabled == true && attackDelay >= 0)
            {
                BroadcastMessage("swapColliderStatus");
                isAttacking = false;
                //Debug.Log("AttackHitbox is off!");
            }
        }

        if(Input.anyKeyDown)
        {
            insertIntoArray(Event.current.keyCode);
            comboExecutionDelay = comboExecutionDelayStore;
        }

        if (comboExecutionDelay <= 0)
        {
            comboListScript.checkIfCombo(lastKeysPressed, isJumping);
        }
    }

    void jump()
    {
        if(transform.position.y < -0.5f)
        {
            jumpVector = transform.position;
            jumpVector.y += jumpSpeed * Time.deltaTime;
            transform.position = jumpVector;
        }
    }
    void drop()
    {
        if(transform.position.y > -2.5f)
        {
            jumpVector = transform.position;
            jumpVector.y -= jumpSpeed * Time.deltaTime;
            transform.position = jumpVector;
        }
        else
        {
            jumpVector.y = -2.5f;
            transform.position = jumpVector;
        }
    }

    // Use this for initialization
    void Start()
    {
        circleCollider = GameObject.Find("AttackRadius").GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        comboListScript = GetComponent<ComboList>();
        dodgeCooldownStore = dodgeCooldown;
        attackDelayStore = attackDelay;
        comboExecutionDelayStore = comboExecutionDelay;
        isAttacking = false;
        isFalling = false;
        lastKeysPressed = new KeyCode[5];
    }

    // Update is called once per frame
    void Update () {
        attackDelay -= Time.deltaTime;
        if(dodgeCooldown >= 0)
        {
            dodgeCooldown -= Time.deltaTime;
        }
        Controls();
	}
}
