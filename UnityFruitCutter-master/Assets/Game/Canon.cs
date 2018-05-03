using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject fromPoint;
    public GameObject toPoint;
    // Use this for initialization
    void Start () {
        this.fromPoint = GameObject.FindGameObjectWithTag("start-point");

        this.toPoint = GameObject.FindGameObjectWithTag("end-point");
        StartCoroutine(randomePosition());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator randomePosition()
    {

        yield return new WaitForSeconds(GlobalSetting.timeBetweenChange);
        this.transform.position = Vector3.right * Random.Range(toPoint.transform.position.x, fromPoint.transform.position.x);
        randomePosition();
        StartCoroutine(randomePosition());

    }



}
