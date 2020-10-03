using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : BaseStats, IEmmitLight, ICanStealth, IAmAffectedByTime
{
    [SerializeField]
    private int emissionDistance;
    public int EmmissionDistance => emissionDistance;

    [SerializeField]
    private EmissionDirection emissionDirection;
    public EmissionDirection EmissionDirection => emissionDirection;

    [SerializeField]
    private int sealth;
    public int STEALTH => sealth;

    [SerializeField]
    private bool isInStealth;
    public bool IsInStealth { get => isInStealth; set => isInStealth = value; }

    [SerializeField]
    private int numOfStepsBeforeEvent;
    public int NumOfStepsBeforeEvent => numOfStepsBeforeEvent;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Color lightColourTint = new Color(255, 217, 128, 0.5f); //#ffd980

    private TimeManager TimeManager;
    private LogManager LogManager;
    private Text healthTxt;

    public void ChangeEmissionDirection(EmissionDirection newDirection)
    {
        emissionDirection = newDirection;
    }

    public void LightenTheArea()
    {
        /*
         *        xxxxx     33.3%   5
         *         xxx      66.6%   3
         *          x       100 %   1
         * */

        int tilesToCover = 1;
        float brightness = 1;
        List<TileBase> tiles = new List<TileBase>();
        Vector3Int playerCoords = tilemap.WorldToCell(transform.position);

        for (int i = 1; i <= emissionDistance; i++, tilesToCover += 2, brightness -= 1 / emissionDistance)
        {
            Vector3Int positionToConsider = new Vector3Int(playerCoords.x, playerCoords.y + i, 0);

            for(int j = -i; j <= i; j++)
            {
                positionToConsider.x = playerCoords.x + j;
                Tile temp = tilemap.GetTile<Tile>(positionToConsider);
                temp.color = new Color(temp.color.r + lightColourTint.r, temp.color.g + lightColourTint.g, temp.color.b + lightColourTint.b, lightColourTint.a);
            }
        }
    }

    public void EnterStealth()
    {
        isInStealth = true;
    }

    public void ExitStealth()
    {
        isInStealth = false;
    }

    private void UpdateUIText()
    {
        healthTxt.text = $"{Health}/{MaxHealth}";
    }

    public void TriggerTimeBasedEvent()
    {
        AlterHealth(-1);
        UpdateUIText();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(Vector3Int.zero);
        LogManager = GetComponent<LogManager>();
        TimeManager = GetComponent<TimeManager>();
        TimeManager.TimeSensitiveObjects.Add(this);
        healthTxt = GameObject.Find("Health").GetComponentInChildren<Text>();
        MaxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
