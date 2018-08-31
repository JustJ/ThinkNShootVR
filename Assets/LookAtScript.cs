using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

    public Transform lookTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lookTarget != null)
        {
            var offset = 2 * transform.position - lookTarget.position;

            transform.LookAt(offset);
        }
	}
}
