using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    LEFT,
    RIGHT,
    STATIONARY,
    ERROR
}

public abstract class ABoardPiece : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    public float Speed { get => speed; protected set => speed = value; }

    [SerializeField]
    private MovementDirection movementDirection = MovementDirection.ERROR;
    public MovementDirection MovementDirection { get => movementDirection; protected set => movementDirection = value; }

    [SerializeField]
    protected Vector2Int spawnCoordinates = Vector2Int.zero;

    protected Grid _grid;

    private void move()
    {
        Vector2 newPos = transform.position;
        newPos.x = movementDirection == MovementDirection.RIGHT ? newPos.x + speed * Time.deltaTime : newPos.x - speed * Time.deltaTime;

        transform.position = newPos;
    }

    protected void putSelfOnBoard()
    {
        Vector3Int coordinates = new Vector3Int(spawnCoordinates.x, spawnCoordinates.y, 0);
        transform.position = _grid.GetCellCenterWorld(coordinates);
    }

    private void OnValidate()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            _grid = FindObjectOfType<Grid>();
            putSelfOnBoard();
        }
    }

    // Start is called before the first frame update
    protected void Start()
    {
        _grid = DependencyContainer.Instance.Get<Grid>();
        if(movementDirection == MovementDirection.ERROR)
        {
            Debug.LogError("The movement direction of this piece has not been set. Please rectify that");
            return;
        }
        putSelfOnBoard();
    }

    // Update is called once per frame
    protected void Update()
    {
        if(movementDirection != MovementDirection.STATIONARY)
        { 
            move();
        }
    }
}
