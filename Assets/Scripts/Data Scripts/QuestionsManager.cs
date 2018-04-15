using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionsManager : MonoBehaviour {


	public CategoriesData[] allCategory;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene("Menu");
	}
	
	public CategoriesData getCurrentCategory(int b) {
		return allCategory[b];
	}

}
