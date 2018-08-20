﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderTrigger : MonoBehaviour {

    public GameObject UIOverlay;
    public int truePoints = 10;
    public int falsePoints = -10;
    public int obstaclePoints = -30;

    int score = 0;
    bool stop = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            transform.Translate(GameObject.Find("CenterEyeAnchor").transform.forward * Time.deltaTime);
        }
        else
        {
            UIOverlay.GetComponentInChildren<Text>().text = "Игра завершена. Счёт: " + score.ToString();
        }
        
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
        else if (collision.gameObject.name == "EndLvlPrefab(Clone)")
        {
            Destroy(collision.gameObject);
            stop = true;
        }

        UIOverlay.GetComponentInChildren<Text>().text = "Счёт: " + score.ToString();
    }
}
