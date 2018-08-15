using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour {

    float speed;
	// Use this for initialization
	void Start () {
        speed = Random.Range(10, 40);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
	}
}
