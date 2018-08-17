using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderTrigger : MonoBehaviour {

    public GameObject UIOverlay;
    public int truePoints = 10;
    public int falsePoints = -10;
    public int obstaclePoints = -30;

    int score = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TrueObjectPrefab")
        {
            score += truePoints;
            UIOverlay.GetComponentInChildren<Text>().text = "Счёт:" + score.ToString();
        }
        else if (collision.gameObject.name == "ObstacleObjectPrefab")
        {
            score += obstaclePoints;
            UIOverlay.GetComponentInChildren<Text>().text = "Счёт:" + score.ToString();
        }
        else if (collision.gameObject.name == "FalseObjectPrefab")
        {
            score += falsePoints;
            UIOverlay.GetComponentInChildren<Text>().text = "Счёт:" + score.ToString();
        }
    }
}
