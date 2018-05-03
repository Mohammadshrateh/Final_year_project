using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {



	public void playButtonClickEvent(){
		Debug.Log ("click");


		SceneManager.LoadScene("Second Scene");
	}

	public void FruitCutterButtonClickEvent(){
		Debug.Log ("click");


		SceneManager.LoadScene("Scene1");
	}

}
