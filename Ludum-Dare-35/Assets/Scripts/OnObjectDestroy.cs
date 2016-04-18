using UnityEngine;
using System.Collections;

public class OnObjectDestroy : MonoBehaviour {

    public float timeBeforeKill;

    private bool isDying = false;

	void OnDestroy()
    {
        GenerateCitizens generateCitizensScript = gameObject.transform.parent.GetComponent<GenerateCitizens>();
        generateCitizensScript.getCitizenAt(generateCitizensScript.getTargetNum()).GetComponent<AvoidPlayer>().doIKnowPlayerFace(true);        
    }

    public float getTimeBeforeKill()
    {
        return timeBeforeKill;
    }

    public void startDying()
    {
        isDying = true;
    }

    void Update()
    {
        if (isDying)
        {
            timeBeforeKill -= Time.deltaTime;
        }

        if(timeBeforeKill <= 0)
        {
            Destroy(gameObject);
        }
    }
}
