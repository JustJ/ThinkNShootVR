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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TrueObjectPrefab(Clone)")
        {
            score += truePoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "ObstacleObjectPrefab(Clone)")
        {
            score += obstaclePoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "FalseObjectPrefab(Clone)")
        {
            score += falsePoints;
            Destroy(collision.gameObject);
        }

        UIOverlay.GetComponentInChildren<Text>().text = "Счёт: " + score.ToString();
    }
}
