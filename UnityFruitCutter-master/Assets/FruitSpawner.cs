using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] appleReference;
	private Vector3 throwForce = new Vector3(0, 30, 0);
	public GameObject startPoint;
	public GameObject endPoint;

    void Start()
    {
        InvokeRepeating("SpawnFruit", 0.5f, 6);
		this.startPoint = GameObject.FindGameObjectWithTag("start-point");

		this.endPoint = GameObject.FindGameObjectWithTag("end-point");
    }

    void SpawnFruit()
    {
		Vector3 spp = startPoint.transform.position;
		Vector3 epp = endPoint.transform.position;
        for (byte i = 0; i < 2; i++)
        {
			GameObject fruit = Instantiate(appleReference[(int)Random.Range(0,appleReference.Length)], new Vector3(Random.Range(-spp.x, spp.x), Random.Range(-25, -35), 30), Quaternion.identity) as GameObject;
			Debug.Log (fruit.transform.position.x);
			Debug.Log (spp.x);
			Debug.Log ("-------------------");
			fruit.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
			fruit.GetComponent<Rigidbody> ().AddTorque (new Vector3(Random.Range(10,300),Random.Range(10,300),Random.Range(10,300)));
        }
    }
}