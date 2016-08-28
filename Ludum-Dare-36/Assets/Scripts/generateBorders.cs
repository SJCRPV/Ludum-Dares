using UnityEngine;
using System.Collections;

public class generateBorders : MonoBehaviour {

    [SerializeField]
    private GameObject topLeftCorner;
    private GameObject topLeftCornerInstance;
    [SerializeField]
    private GameObject topRightCorner;
    private GameObject topRightCornerInstance;
    [SerializeField]
    private GameObject bottomLeftCorner;
    private GameObject bottomLeftCornerInstance;
    [SerializeField]
    private GameObject bottomRightCorner;
    private GameObject bottomRightCornerInstance;
    [SerializeField]
    private GameObject vertWall;
    private GameObject vertWallInstance;
    [SerializeField]
    private GameObject horWall;
    private GameObject horWallInstance;
    private double numOfVertWalls;
    private double numOfHorWalls;

    private void setCorners()
    {
        topLeftCornerInstance = (GameObject)Instantiate(topLeftCorner, new Vector2(-18.2f, 7.75f), Quaternion.identity);
        topLeftCornerInstance.transform.parent = this.transform;
        topRightCornerInstance = (GameObject)Instantiate(topRightCorner, new Vector2(18.2f, 7.75f), Quaternion.identity);
        topRightCornerInstance.transform.parent = this.transform;
        bottomLeftCornerInstance = (GameObject)Instantiate(bottomLeftCorner, new Vector2(-18.2f, -6.75f), Quaternion.identity);
        bottomLeftCornerInstance.transform.parent = this.transform;
        bottomRightCornerInstance = (GameObject)Instantiate(bottomRightCorner, new Vector2(18.2f, -6.75f), Quaternion.identity);
        bottomRightCornerInstance.transform.parent = this.transform;
    }

    private void calculateDimensions()
    {
        numOfVertWalls = Mathf.Abs(((topLeftCornerInstance.transform.position.y - 0.5f) - (bottomLeftCornerInstance.transform.position.y + 0.5f))) / 0.5f;
        numOfVertWalls = Mathf.CeilToInt((float)numOfVertWalls);
        //Debug.Log((topLeftCornerInstance.transform.position.y - 0.5f) + " - " + (bottomLeftCorner.transform.position.y) + " / 0.5 = " + numOfVertWalls);

        numOfHorWalls = Mathf.Abs(((topLeftCornerInstance.transform.position.x + 0.5f) - (topRightCornerInstance.transform.position.x - 0.5f))) / 0.5f;
        numOfHorWalls = Mathf.CeilToInt((float)numOfHorWalls);
        //Debug.Log((topLeftCornerInstance.transform.position.x + 0.5f) + " - " + (topRightCornerInstance.transform.position.x) + " / 0.5 = " + numOfHorWalls);
    }

    private void instantiateWalls()
    {
        Vector2 tempTopLeft = topLeftCornerInstance.transform.position;
        Vector2 tempTopRight = topRightCornerInstance.transform.position;
        Vector2 tempBotLeft = bottomLeftCornerInstance.transform.position;

        for(int i = 1; i <= numOfHorWalls + 1; i++)
        {
            horWallInstance = (GameObject)Instantiate(horWall, new Vector2(tempTopLeft.x + 0.5f * i, tempTopLeft.y), Quaternion.identity);
            horWallInstance.transform.parent = this.transform;
            horWallInstance = (GameObject)Instantiate(horWall, new Vector2(tempBotLeft.x + 0.5f * i, tempBotLeft.y), Quaternion.identity);
            horWallInstance.transform.parent = this.transform;
        }

        for (int i = 1; i <= numOfVertWalls + 1; i++)
        {
            vertWallInstance = (GameObject)Instantiate(vertWall, new Vector2(tempTopLeft.x, tempTopLeft.y - 0.5f * i), Quaternion.identity);
            vertWallInstance.transform.parent = this.transform;
            vertWallInstance = (GameObject)Instantiate(vertWall, new Vector2(tempTopRight.x, tempTopRight.y - 0.5f * i), Quaternion.identity);
            vertWallInstance.transform.parent = this.transform;
        }
    }

    // Use this for initialization
    void Start () {
        setCorners();
        calculateDimensions();
        instantiateWalls();
    }
}
