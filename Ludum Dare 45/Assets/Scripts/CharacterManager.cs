using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public List<GameObject> charactersList;
    public int NumOfCharacters { get; private set; } = 0;
    [SerializeField]
    private GameObject characterPrefab;
    private Transform charactersManagerObj;
    private int currControlledCharacterIndex;

    public void ClearList()
    {
        foreach (GameObject character in charactersList)
        {
            character.GetComponent<CharacterControls>().ReleaseControl();
            Destroy(character);
        }
        currControlledCharacterIndex = -1;
        charactersList.Clear();
    }

    public void SwapToNextCharacter()
    {
        charactersList[currControlledCharacterIndex++].GetComponent<CharacterControls>().ReleaseControl();
        if(currControlledCharacterIndex == charactersList.Count)
        {
            currControlledCharacterIndex = 0;
        }
        charactersList[currControlledCharacterIndex].GetComponent<CharacterControls>().TakeControl();
    }

    private void swapToCharacterNumber(int index)
    {
        charactersList[currControlledCharacterIndex].GetComponent<CharacterControls>().ReleaseControl();
        currControlledCharacterIndex = index;
        charactersList[currControlledCharacterIndex].GetComponent<CharacterControls>().TakeControl();
    }

    public void SpawnCharacterAt(Vector3 position, bool controlThisCharacter = false)
    {
        GameObject character = Instantiate(characterPrefab, charactersManagerObj, false);
        character.transform.localPosition = position;
        charactersList.Add(character);
        NumOfCharacters++;
        if(controlThisCharacter)
        {
            character.GetComponent<CharacterControls>().TakeControl();
        }
    }

    private void spawnInitialChar()
    {
        int xCoord = Mathf.RoundToInt(Random.Range(-1, 1));
        int yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
        Destroy(GameObject.Find("Grid").transform.Find(xCoord + ", " + yCoord).gameObject);
        Vector3 charPosition = GameObject.Find("Grid").GetComponent<Grid>().GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
        SpawnCharacterAt(charPosition);
        charactersList[0].GetComponent<CharacterControls>().TakeControl();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        charactersList = new List<GameObject>();
        charactersManagerObj = GameObject.Find("Characters").transform;
        spawnInitialChar();
    }

    private void checkForCharacterSwaps()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            swapToCharacterNumber(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            swapToCharacterNumber(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            swapToCharacterNumber(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            swapToCharacterNumber(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForCharacterSwaps();
    }
}
