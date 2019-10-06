using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject weakPointPrefab;
    [SerializeField]
    private GameObject attackAreaPrefab;
    private GameObject attackObj;
    [SerializeField]
    private Vector3 positionCorrection;
    public Vector3 PositionCorrection { get { return positionCorrection; } }
    [SerializeField]
    private int cellsWide;
    public int CellsWide { get { return cellsWide; } set { cellsWide = value; } }
    [SerializeField]
    private int cellsTall;
    public int CellsTall { get { return cellsTall; } set { cellsTall = value; } }
    public bool IsActivated { get; set; }
    [SerializeField]
    private int stepsBeforeAttack;
    [SerializeField]
    private int stepsOfAttackLeniency;
    private int stepCounter;
    public int StepCounter
    {
        get
        {
            return stepCounter;
        }

        set
        {
            stepCounter = value;
            if(stepCounter == stepsBeforeAttack - stepsOfAttackLeniency)
            {
                prepareAttack();
            }
            else if(stepCounter == stepsBeforeAttack)
            {
                attack();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent.gameObject.name.Contains("Characters"))
        {
            IsActivated = true;
            StepCounter = 1;
        }
        if(collision.gameObject.name.Contains("Block"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject.name.Contains("Characters"))
        {
            IsActivated = false;
            StepCounter = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.parent.gameObject.name.Contains("Characters"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void attack()
    {
        foreach (Transform block in attackObj.transform)
        {
            block.GetComponent<BoxCollider2D>().enabled = true;
            Color color = block.GetComponent<SpriteRenderer>().color;
            color.a = 1;
            block.GetComponent<SpriteRenderer>().color = color;
        }
        stepCounter = 0;
    }

    private void prepareAttack()
    {
        if(attackObj != null)
        {
            Destroy(attackObj);
        }
        Color color = LevelAssembler.instance.PossibleColours[Random.Range(0, LevelAssembler.instance.PossibleColours.Count)];
        color.a = 0.5f;
        attackObj = Instantiate(attackAreaPrefab, transform, false);
        foreach (Transform block in attackObj.transform)
        {
            block.GetComponent<BoxCollider2D>().enabled = false;
            block.GetComponent<SpriteRenderer>().color = color;
        }
    }

    private void spawnReward()
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        Vector3Int cellPos = grid.LocalToCell(transform.localPosition);
        Vector3 localPos = grid.GetCellCenterLocal(cellPos);

        if (LevelManager.instance.enemiesStillInTheLevel.Count - 1 > 0)
        {            
            CharacterManager.instance.SpawnCharacterAt(localPos);
        }
        else
        {
            GameObject stairsObj = LevelManager.instance.stairsPrefab;
            Instantiate(stairsObj, grid.transform, false);
            stairsObj.transform.localPosition = localPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Collider2D[] results = new Collider2D[] { };
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Physics2D.OverlapBox(transform.localPosition, boxCollider.size, 0, contactFilter2D.NoFilter(), results);
        foreach (Collider2D result in results)
        {
            Destroy(result.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.Find("WeakPoint") == null)
        {
            spawnReward();
            LevelManager.instance.enemiesStillInTheLevel.Remove(this);
            Destroy(gameObject);
        }
    }
}
