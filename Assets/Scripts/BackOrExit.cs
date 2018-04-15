using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackOrExit : MonoBehaviour {

	public GameObject enable;
	public GameObject disable;
	public GameObject panelExit;

	public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (sceneName != string.Empty) {
				SceneManager.LoadScene(sceneName);
			} else if (sceneName == string.Empty && enable != null && disable != null) {
				enable.SetActive(true);
				disable.SetActive(false);
			}
		}
	}

	public void backGO() {
		enable.SetActive(true);
		disable.SetActive(false);
	}

	public void backScene() {
		SceneManager.LoadScene(sceneName);
	}

	public void confirmExit () {
		panelExit.SetActive(true);
	}

	public void cancelExit () {
		panelExit.SetActive(false);
	}

	public void exit() {
		Application.Quit();
	}
}
