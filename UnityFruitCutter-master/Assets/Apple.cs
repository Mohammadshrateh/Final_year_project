using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private GameObject splashReference;
    private Vector3 randomPos = new Vector3(Random.Range(-1, 1), Random.Range(0.3f, 0.7f), Random.Range(-6.5f, -7.5f));
	private GUIText scoreReference;

    void Start()
    {
		scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
    }
    
    void Update()
    {
        /* Remove fruit if out of view */
        if (gameObject.transform.position.y < -36)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "mohammad")
        {
			Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject);
			Vector3 pos = this.transform.position;


			Instantiate(splashReference, pos, Quaternion.identity);

			/* Update Score */

			scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
        }
    }
}