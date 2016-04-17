using UnityEngine;
using System.Collections;

public class OnObjectDestroy : MonoBehaviour {

	void OnDestroy()
    {
        GenerateCitizens generateCitizensScript = gameObject.transform.parent.GetComponent<GenerateCitizens>();
        generateCitizensScript.getCitizenAt(generateCitizensScript.getTargetNum()).GetComponent<AvoidPlayer>().doIKnowPlayerFace(true);        
    }
}
