using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;
    public Enemy CurrentEnemy { get; set; }
    private Transform parentTransform;

    [SerializeField]
    private int currentEnemyIndex = 0;
    [SerializeField]
    private int currentLevelNum = 1;
    [SerializeField]
    private GameObject[] levelOneEnemies;
    [SerializeField]
    private GameObject[] levelTwoEnemies;
    [SerializeField]
    private GameObject[] levelThreeEnemies;

    private IEnumerator godlyInteraction()
    {
        while(InteractionWithGod.instance.IsInteractingWithGod)
        {
            yield return null;
        }
        currentLevelNum++;
        currentEnemyIndex = 0;
        BeatManager.instance.IsDroppingBeats = false;
        InteractionWithGod.instance.IsInteractingWithGod = true;
    }

    private GameObject[] getEnemiesFromThisLevel()
    {
        return currentLevelNum == 1 ? levelOneEnemies : currentLevelNum == 2 ? levelTwoEnemies : levelThreeEnemies;
    }

    public void NextEnemy()
    {
        GameObject[] currentLevel = getEnemiesFromThisLevel();

        if(currentEnemyIndex >= currentLevel.Length)
        {
            StartCoroutine(godlyInteraction());
        }

        CurrentEnemy = Instantiate(currentLevel[currentEnemyIndex++], parentTransform, false).GetComponent<Enemy>();
    }

    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        parentTransform = GameObject.Find("Enemy").transform;
        NextEnemy();
	}
}
