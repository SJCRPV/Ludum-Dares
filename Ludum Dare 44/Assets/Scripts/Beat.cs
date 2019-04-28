using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private bool canBeDestroyed = false;

    [SerializeField]
    private float scrollRightSpeed;

    public bool AttacksFromTheLeft { get; private set; }
    public int AttackModifier { get; private set; }

    public enum AttackModifiers
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    private void OnBecameVisible()
    {
        canBeDestroyed = true;
    }

    private void OnBecameInvisible()
    {
        if(canBeDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private int deduceSpriteIndex()
    {
        switch(AttackModifier)
        {
            case 0:
                return AttacksFromTheLeft ? (int)BeatList.beatListEnum.LEFT_FIST_UP_MOD : (int)BeatList.beatListEnum.RIGHT_FIST_UP_MOD;
            case 1:
                return AttacksFromTheLeft ? (int)BeatList.beatListEnum.LEFT_FIST_RIGHT_MOD : (int)BeatList.beatListEnum.RIGHT_FIST_RIGHT_MOD;
            case 2:
                return AttacksFromTheLeft ? (int)BeatList.beatListEnum.LEFT_FIST_DOWN_MOD : (int)BeatList.beatListEnum.RIGHT_FIST_DOWN_MOD;
            case 3:
                return AttacksFromTheLeft ? (int)BeatList.beatListEnum.LEFT_FIST_LEFT_MOD : (int)BeatList.beatListEnum.RIGHT_FIST_LEFT_MOD;
            default:
                throw new Exception("I don't know what attack modifier you gave me. Have a look: " + AttackModifier);
        }
    }

    public void ControlledInit(bool isAttackingFromLeft, int attackModifier)
    {
        AttacksFromTheLeft = isAttackingFromLeft;
        AttackModifier = attackModifier;
        if(attackModifier != -1)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = BeatList.getSpecificBeat(deduceSpriteIndex());
        }
    }

    private void parseSpriteName()
    {
        string spriteName = spriteRenderer.sprite.name;

        AttacksFromTheLeft = spriteName.Contains("LeftFist");

        if(spriteName.Contains("UpMod")) { AttackModifier = (int)AttackModifiers.UP; }
        if(spriteName.Contains("RightMod")) { AttackModifier = (int)AttackModifiers.RIGHT; }
        if(spriteName.Contains("DownMod")) { AttackModifier = (int)AttackModifiers.DOWN; }
        if(spriteName.Contains("LeftMod")) { AttackModifier = (int)AttackModifiers.LEFT; }
    }

    public void RandomInit()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BeatList.getRandomBeat();
        parseSpriteName();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x += scrollRightSpeed * Time.deltaTime;

        transform.position = newPos;
    }
}
