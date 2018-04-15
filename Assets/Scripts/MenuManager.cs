using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public DataController dataController;
	public QuestionsManager questionsManager;
	public string nameGameScene;
	public GameObject setting_Panel;
	public Image level1Image;
	public Image level2Image;
	public Image level3Image;

	public Sprite enableLevelSprite;
	public Sprite disableLevelSprite;

	
	// Use this for initialization
	void Start () {
		dataController = FindObjectOfType<DataController> ();
		questionsManager = FindObjectOfType<QuestionsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void categorySelect() {

		if (dataController.categorySelected == 0) {
			nameGameScene = "Fruits";
		} else if (dataController.categorySelected == 1) {
			nameGameScene = "Vegetables";
		} else if (dataController.categorySelected == 2) {
			nameGameScene = "Animals";
		}

	}

	public void setting() {
		setting_Panel.SetActive(true);
	}

	public void cancelSetting () {
		setting_Panel.SetActive(false);
	}

	public void loadSceneGame() {
		SceneManager.LoadScene(nameGameScene);
	}

	public void categorySelector(int a) {
		dataController.categorySelected = a;
		dataController.categoryDataSelected = questionsManager.getCurrentCategory(dataController.categorySelected);

	}

	public void levelSelector(int a) {

		dataController.levelSelected = a;
		dataController.LevelDataSelected = dataController.categoryDataSelected.getCurrentLevelsData(dataController.levelSelected);
		dataController.questions = dataController.LevelDataSelected.questionsData;

	}

}
