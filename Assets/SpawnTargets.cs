using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTargets : MonoBehaviour {

    public GameObject trueObject;
    public GameObject falseObject;
    public GameObject obstacleObject;

    float distanceTravelled = 0;
    Vector3 lastPosition;
    GameObject lastObjectSpawned;
    List<GameObject> gameObjects;

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
        lastObjectSpawned = generateNextObject();
    }
	
	// Update is called once per frame
	void Update () {

        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if (distanceTravelled > 7)
        {
            if (lastObjectSpawned)
            {
                Destroy(lastObjectSpawned);
            }
            lastObjectSpawned = generateNextObject();
            distanceTravelled = 0;
        }
    }

    float obstacleProb = 0.2f;
    float trueObjProb = 0.4f;
    float falseObjProb = 0.4f;
    GameObject generateNextObject()
    {
        GameObject spawnedObject = null;
        float curObjectProb = Random.Range(0f, 1f);

        if (curObjectProb < obstacleProb) { spawnedObject = generateObstacle(); }
        else if (curObjectProb < obstacleProb + trueObjProb) { spawnedObject = generateTrueObject(); }
        else if (curObjectProb <= obstacleProb + trueObjProb + falseObjProb) { spawnedObject = generateFalseObject(); }

        return spawnedObject;
    }

    GameObject generateObstacle()
    {
        Vector3 curPos = transform.position + transform.forward * 6f;
        return Instantiate(obstacleObject, curPos, Quaternion.identity);
    }
    GameObject generateTrueObject()
    {
        Vector3 curPos = transform.position + transform.forward * 6f;
        return Instantiate(trueObject, curPos, Quaternion.identity);
    }
    GameObject generateFalseObject()
    {
        Vector3 curPos = transform.position + transform.forward * 6f;
        return Instantiate(falseObject, curPos, Quaternion.identity);
    }
}
