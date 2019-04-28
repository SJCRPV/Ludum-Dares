using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatList : MonoBehaviour {    

    public Sprite[] beatList;
    private static Dictionary<int, Sprite> staticBeatList;

    public enum beatListEnum
    {
        LEFT_FIST_UP_MOD,
        LEFT_FIST_RIGHT_MOD,
        LEFT_FIST_DOWN_MOD,
        LEFT_FIST_LEFT_MOD,
        RIGHT_FIST_UP_MOD,
        RIGHT_FIST_RIGHT_MOD,
        RIGHT_FIST_DOWN_MOD,
        RIGHT_FIST_LEFT_MOD
    }

    public static Sprite getRandomBeat()
    {
        int index = Random.Range(0, staticBeatList.Count);
        return staticBeatList[index];
    }

    public static Sprite getSpecificBeat(int index)
    {
        return staticBeatList[index];
    }

	// Use this for initialization
	void Start () {
        staticBeatList = new Dictionary<int, Sprite>();
        for(int i = 0; i < beatList.Length; i++)
        {
            staticBeatList.Add(i, beatList[i]);
        }
	}
}
