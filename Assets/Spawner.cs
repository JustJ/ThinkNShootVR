using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour {
    
    public int TargetCount = 0;
    public GameObject target;
    
    List<GameObject> instantietedTargets;
	// Use this for initialization
	void Start () {
        float x = 40;
        float y = 0;
        float z = 40;
        instantietedTargets = new List<GameObject>();
        for (int i = 0; i < TargetCount; i++)
        {
            Vector3 spawnPos = new Vector3(x, y + i * 10, z - i * 5);
            instantietedTargets.Add(Instantiate(target, spawnPos, new Quaternion(0,0,0,0)));
            instantietedTargets[i].AddComponent<TextMeshPro>();
            
            instantietedTargets[i].GetComponent<TextMeshPro>().SetText("Target num.#" + i.ToString());
            TMP_FontAsset font = Resources.Load("Fonts/Roboto-Regular", typeof(TMP_FontAsset)) as TMP_FontAsset;
            instantietedTargets[i].GetComponent<TextMeshPro>().font = font;
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var item in instantietedTargets)
        {
            item.SetActive(true);
        }
	}
}
