using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public static DataController instance;
	public int categorySelected;
	public int levelSelected;
	public QuestionsManager questionsManager;
	public CategoriesData categoryDataSelected;
	public LevelData LevelDataSelected;
	public QuestionsData[] questions;

	// Use this for initialization
	void Start () {
		

		if (instance != null) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}

		questionsManager = FindObjectOfType<QuestionsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
