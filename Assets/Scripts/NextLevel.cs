using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	private DataController dataController;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable () {
		dataController = FindObjectOfType <DataController> ();

		if (dataController.levelSelected == 2) {
			gameObject.SetActive (true);
		}
	}



}
