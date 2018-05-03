using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateFruits : MonoBehaviour {
    public GameObject[] fruits=new GameObject[3];
	// Use this for initialization
	void Start () {

        StartCoroutine(newGameInstanciate());

    }

    // Update is called once per frame
    void Update () {
		
	}


    IEnumerator newGameInstanciate()
    {

        yield return new WaitForSeconds(3);
        GameObject.Instantiate(fruits[(int)Random.Range(0,3)],this.transform.position,Quaternion.identity);
        StartCoroutine(newGameInstanciate());

    }



}
