using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnColumnOfPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private Transform initialPointOfReference = null;
    [SerializeField]
    private string instanceNamePrefix = "";

    private int numberOfRows = 22;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRows = DependencyContainer.Instance.Get<GlobalVariables>().NumberOfRows;

        for (int i = 0; i < numberOfRows; i++)
        {
            Vector3 spawnPosition = initialPointOfReference.position;
            spawnPosition.y -= i;
            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity, parent: transform);
            instance.name = $"{instanceNamePrefix} {i}";
        }

        try
        {
            initialPointOfReference.GetComponent<SpriteRenderer>().enabled = false;
        }
        catch (System.Exception)
        {
            initialPointOfReference.GetComponent<Image>().enabled = false;
        }
    }
}
