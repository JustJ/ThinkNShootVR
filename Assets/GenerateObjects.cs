using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {

    public GameObject trueObjectPref;
    public GameObject falseObjectPref;
    public GameObject obstacleObjectPref;

    public GameObject endLvlObjectPref;

    public float genAreaHeight = 2.2f;
    public float genAreaWidth = 2.2f;

    public int maxObjectsToEndLevel = 100;

    Vector3 lastGenPos;
    // Use this for initialization
    void Start () {
        lastGenPos = new Vector3(0, 0, 0);

        for (int i = 0; i < maxObjectsToEndLevel; i++)
        {
            generateNextObject();
        }

        generateObject(endLvlObjectPref);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float obstacleProb = 0.2f;
    public float trueObjProb = 0.4f;
    public float falseObjProb = 0.4f;
    GameObject generateNextObject()
    {
        GameObject spawnedObject = null;
        float curObjectProb = Random.Range(0f, 1f);

        if (curObjectProb < obstacleProb) { spawnedObject = generateObject(obstacleObjectPref); }
        else if (curObjectProb < obstacleProb + trueObjProb) { spawnedObject = generateObject(trueObjectPref); }
        else if (curObjectProb <= obstacleProb + trueObjProb + falseObjProb) { generateObject(falseObjectPref); }

        return spawnedObject;
    }
    
    GameObject generateObject(GameObject obj)
    {
        Vector3 curPos = new Vector3(Random.Range(-genAreaWidth, genAreaWidth), Random.Range(-genAreaHeight, genAreaHeight), lastGenPos.z + Random.Range(8, 14));
        lastGenPos = curPos;
        return Instantiate(obj, curPos, Quaternion.identity);
    }
}
