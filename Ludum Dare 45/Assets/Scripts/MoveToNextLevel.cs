using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Character"))
        {
            LevelManager.instance.ClearLevel();
            CharacterManager.instance.ClearList();
            LevelAssembler.instance.DefineGenerationParameters(++LevelManager.instance.levelCounter);
            LevelAssembler.instance.GenerateLevel();
        }
    }
}
