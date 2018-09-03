using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class ColliderTrigger : MonoBehaviour {

    public GameObject UIOverlay;
    public int truePoints = 10;
    public int falsePoints = -10;
    public int obstaclePoints = -30;
    public int trueTextPoints = 100;
    public int falseTextPoints = -200;
    public int speed = 5;

    public int pointsToActivateExit = 300;

    public float lvlTime = 60;

    int score = 0;
    bool stop = false;
    // Use this for initialization
    void Start () {
		
	}
	
    public void addFalseTextScore()
    {
        score += falseTextPoints;
        showScore();
    }

    public void addTrueTextScore()
    {
        score += trueTextPoints;
        showScore();
    }

    void showScore()
    {
        UIOverlay.GetComponentInChildren<Text>().text = "Время: " + lvlTime.ToString("N2") +"сек. " + "Счёт: " + score.ToString() + "/" + pointsToActivateExit.ToString();
    }

    void checkScore()
    {
        if (score >= pointsToActivateExit)
        {
            MeshRenderer mr = GameObject.Find("/EndLvlPrefab(Clone)").GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = Resources.Load<Material>("Materials/EndLvlMatActive");
            mr.materials = mats;
        }
        else
        {
            MeshRenderer mr = GameObject.Find("/EndLvlPrefab(Clone)").GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = Resources.Load<Material>("Materials/EndLvlMatInactive");
            mr.materials = mats;
        }
    }

    void endTimerTick()
    {
        lvlTime -= Time.deltaTime;

        if (lvlTime < 0)
        {
            stop = true;
        }
    }

    void moveForward()
    {
        transform.Translate(speed * GameObject.Find("CenterEyeAnchor").transform.forward * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {

        if (!stop)
        {
            moveForward();
            endTimerTick();
            checkScore();
            showScore();
        }
        else
        {
            UIOverlay.GetComponentInChildren<Text>().text = "Игра завершена. Счёт: " + score.ToString();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!stop)
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
                if (score >= pointsToActivateExit)
                {
                    Destroy(collision.gameObject);
                    stop = true;
                }
            }
            else if (collision.gameObject.name == "TrueTextObjectPrefab(Clone)")
            {
                score += trueTextPoints;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "FalseTextObjectPrefab(Clone)")
            {
                score += falseTextPoints;
                Destroy(collision.gameObject);
            }
        }
        showScore();
    }
}
