using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb= this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up*500);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
