using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (this.gameObject.tag == "start-point")
        {
			this.transform.position = /*this.transform.position.x +*/new Vector3(40,0,32);
        }
        else
        {
			this.transform.position =/* this.transform.position +*/new Vector3(-40,0,32);
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
