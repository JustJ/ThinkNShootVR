using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

    public Transform lookTarget;
    Vector3 startPos;
    Transform ovrCamera;
    // Use this for initialization
    void Start () {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(lookTarget != null)
        {
            if (this.name == "arrow" || this.name == "ArrowHolder")
            {
                lookTarget = GameObject.Find("/EndLvlPrefab(Clone)").GetComponent<Transform>();
                ovrCamera = GameObject.Find("/OVRCameraRig").GetComponent<Transform>();
                transform.position = ovrCamera.position + startPos;
                
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
