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
            if (this.name == "arrow")
            {
                lookTarget = GameObject.Find("/EndLvlPrefab(Clone)").GetComponent<Transform>();
                var offset = transform.position - lookTarget.position;
                transform.LookAt(lookTarget);
                transform.Rotate(-90, 0, 0);
            }
            else
            {
                var offset = 2 * transform.position - lookTarget.position;
                transform.LookAt(offset);
            }
        }
	}
}
