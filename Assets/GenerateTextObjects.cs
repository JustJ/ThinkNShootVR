using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateTextObjects : MonoBehaviour {

    public GameObject trueObjectPref;
    public GameObject falseObjectPref;
    public GameObject testObjectPref;

    public TextAsset trueSource;
    public TextAsset falseSource;

    public float genAreaHeight = 2.2f;
    public float genAreaWidth = 2.2f;

    public int maxObjects = 10;

    public float trueTextProb = 0.5f;
    public float falseTextProb = 0.5f;

    Vector3 lastGenPos;

    List<string> trueStrings;
    List<string> falseStrings;

    // Use this for initialization
    void Start () {
        Encoding unicode = Encoding.GetEncoding(65001);

        lastGenPos = new Vector3(0, 0, 0);
        trueStrings = new List<string>();
        falseStrings = new List<string>();

        trueStrings.AddRange(Regex.Split(unicode.GetString(trueSource.bytes), "\r\n|\r|\n"));
        falseStrings.AddRange(Regex.Split(unicode.GetString(falseSource.bytes), "\r\n|\r|\n"));

        for (int i = 0; i < maxObjects; i++)
        {
            generateNextObject();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    GameObject generateNextObject()
    {
        GameObject spawnedObject = null;
        float curObjectProb = Random.Range(0f, 1f);

        if (curObjectProb < trueTextProb)
        {
            if (trueStrings.Count != 0)
            {
                spawnedObject = generateObject(trueObjectPref);
                spawnedObject.GetComponentInChildren<TextMeshProUGUI>().text = trueStrings[0];

                trueStrings.Remove(trueStrings[0]);
            }

        }
        else if (curObjectProb < trueTextProb + falseTextProb) {
            if (falseStrings.Count != 0)
            {
                spawnedObject = generateObject(falseObjectPref);
                spawnedObject.GetComponentInChildren<TextMeshProUGUI>().text = falseStrings[0];

                falseStrings.Remove(falseStrings[0]);
            }
        }

        return spawnedObject;
    }

    GameObject generateObject(GameObject obj)
    {
        Vector3 curPos = new Vector3(Random.Range(-genAreaWidth, genAreaWidth), Random.Range(-genAreaHeight, genAreaHeight), Random.Range(-genAreaHeight, genAreaHeight) + 5);
        lastGenPos = curPos;
        GameObject ret = Instantiate(obj, curPos, Quaternion.identity);
        ret.transform.rotation = Random.rotation;
        ret.SetActive(true);
        return ret;
    }
}