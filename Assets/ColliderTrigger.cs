using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    public AudioSource audioSource;
    public AudioClip greenSound;
    public AudioClip redSound;
    public AudioClip obstacleSound;

    int score = 0;
    bool stop = false;
    Text scoreText;
    Text logText;
    Vector3 colliderPos;
    string logFilePath;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("/UIOver/TextScore").GetComponent<Text>();
        logText = GameObject.Find("/UIOver/EventLog").GetComponent<Text>();
        logText.text = "";
        colliderPos = transform.position;

        createLogFile();
    }

    void createLogFile()
    {
        string timeString = System.DateTime.Now.ToString("HH-mm-ss dd MMMM, yyyy");
        logFilePath = Application.persistentDataPath + "/LogFile - " + timeString + ".txt";
        try
        {
            File.Create(logFilePath);
        }
        catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    public void trueTextClicked(TextMeshProUGUI textObject)
    {
        string textFromObject = textObject.text + "\n";
        score += trueTextPoints;
        logText.text = "Верно! +" + trueTextPoints.ToString() + "\n";
        File.AppendAllText(logFilePath, logText.text);
        logText.color = Color.green;
        File.AppendAllText(logFilePath, textFromObject);
    }

    public void falseTextClicked(TextMeshProUGUI textObject)
    {
        string textFromObject = textObject.text + "\n";
        score += falseTextPoints;
        logText.text = "Неверно! " + falseTextPoints.ToString() + "\n";
        File.AppendAllText(logFilePath, logText.text);
        logText.color = Color.red;
        File.AppendAllText(logFilePath, textFromObject);
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
        scoreText.text = "Время: " + lvlTime.ToString("N2") + "сек.\n" + "Счёт: " + score.ToString() + "/" + pointsToActivateExit.ToString(); ;
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
        GameObject.Find("OVRCameraRig").transform.Translate(speed * GameObject.Find("CenterEyeAnchor").transform.forward * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {

        transform.position = GameObject.Find("OVRCameraRig").transform.position + colliderPos;

        if (!stop)
        {
            moveForward();
            endTimerTick();
            checkScore();
            showScore();
        }
        else
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("TrueText"))
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FalseText"))
            {
                obj.SetActive(false);
            }

            PlayerPrefs.SetInt("score", score);

            if (score >= pointsToActivateExit)
            {
                SceneManager.LoadScene("Win_scene", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("Loose_scene", LoadSceneMode.Single);
            }


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
                logText.text = "Зелёный шар! +" + truePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.green;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(greenSound);
            }
            else if (collision.gameObject.name == "ObstacleObjectPrefab(Clone)")
            {
                score += obstaclePoints;
                logText.text = "Препятствие! " + obstaclePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.yellow;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(obstacleSound);
            }


            else if (collision.gameObject.name == "AsteroidElectric_Green3(Clone)")
            {
                score += obstaclePoints;
                logText.text = "Препятствие! " + obstaclePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.yellow;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(obstacleSound);
            }

            else if (collision.gameObject.name == "AsteroidElectric_Violet5(Clone)")
            {
                score += obstaclePoints;
                logText.text = "Препятствие! " + obstaclePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.yellow;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(obstacleSound);
            }

            else if (collision.gameObject.name == "AsteroidElectric_Yellow1(Clone)")
            {
                score += obstaclePoints;
                logText.text = "Препятствие! " + obstaclePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.yellow;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(obstacleSound);
            }

            else if (collision.gameObject.name == "AsteroidElectric_Red1")
            {
                score += obstaclePoints;
                logText.text = "Препятствие! " + obstaclePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.yellow;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(obstacleSound);
            }



            else if (collision.gameObject.name == "AsteroidElectric_Blue1(Clone)")
            {
                score += falsePoints;
                logText.text = "Красный шар! " + falsePoints.ToString() + "\n";
                File.AppendAllText(logFilePath, logText.text);
                logText.color = Color.red;
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(redSound);
            }
            else if (collision.gameObject.name == "EndLvlPrefab(Clone)")
            {
                if (score >= pointsToActivateExit)
                {
                    Destroy(collision.gameObject);
                    stop = true;
                }
            }
        }
    }
}
