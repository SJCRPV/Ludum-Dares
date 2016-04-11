using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    CharacterStats characterStatsScript;

    // Use this for initialization
    void Start()
    {
        characterStatsScript = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterStatsScript.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
