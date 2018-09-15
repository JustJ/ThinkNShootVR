using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectsToSphere : MonoBehaviour {

    public GameObject trueObjectPref;
    public GameObject trueObjectPref2;
    public GameObject trueObjectPref3;
    public GameObject trueObjectPref4;
    public GameObject falseObjectPref;
    public GameObject obstacleObjectPref;
    public GameObject obstacleObjectPref2;
    public GameObject obstacleObjectPref3;
    public GameObject endLvlObjectPref;

    public float genAreaHeight = 2.2f;
    public float genAreaWidth = 2.2f;

    public int maxObjectsToEndLevel = 10;

    Vector3 lastGenPos;
    // Use this for initialization
    void Start()
    {
        lastGenPos = new Vector3(0, 0, 0);

        for (int i = 0; i < maxObjectsToEndLevel; i++)
        {
            generateNextObject();
        }
        generateObject(endLvlObjectPref);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float obstacleProb = 0.1f;
    public float obstacleProb2 = 0.1f;
    public float obstacleProb3 = 0.1f;
    public float trueObjProb = 0.11f;
    public float trueObjProb2 = 0.11f;
    public float trueObjProb3 = 0.11f;
    public float trueObjProb4 = 0.12f;
    public float falseObjProb = 0.35f;
    GameObject generateNextObject()
    {
        GameObject spawnedObject = null;
        float curObjectProb = Random.Range(0f, 1f);

        if (curObjectProb < obstacleProb) { spawnedObject = generateObject(obstacleObjectPref); }
        else if (curObjectProb < obstacleProb + obstacleProb2) { spawnedObject = generateObject(obstacleObjectPref2); }
        else if (curObjectProb < obstacleProb + obstacleProb2 + obstacleProb3) { spawnedObject = generateObject(obstacleObjectPref3); }
        else if (curObjectProb < obstacleProb + obstacleProb2 + obstacleProb3 + trueObjProb) { spawnedObject = generateObject(trueObjectPref); }
        else if (curObjectProb < obstacleProb + obstacleProb2 + obstacleProb3 + trueObjProb + trueObjProb2) { spawnedObject = generateObject(trueObjectPref2); }
        else if (curObjectProb < obstacleProb + obstacleProb2 + obstacleProb3 + trueObjProb + trueObjProb2 + trueObjProb3) { spawnedObject = generateObject(trueObjectPref3); }
        else if (curObjectProb < obstacleProb + obstacleProb2 + obstacleProb3 + trueObjProb + trueObjProb2 + trueObjProb3 + +trueObjProb4) { spawnedObject = generateObject(trueObjectPref4); }
        else if (curObjectProb <= obstacleProb + obstacleProb2 + obstacleProb3 + trueObjProb + trueObjProb2 + falseObjProb) { generateObject(falseObjectPref); }

        return spawnedObject;
    }

    GameObject generateObject(GameObject obj)
    {
        Vector3 curPos = new Vector3(Random.Range(-genAreaWidth, genAreaWidth), Random.Range(-genAreaHeight, genAreaHeight), Random.Range(-genAreaHeight, genAreaHeight) + 65);
        lastGenPos = curPos;
        return Instantiate(obj, curPos, Quaternion.identity);
    }
}
