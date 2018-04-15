using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	public Text finalScore;
	public GameObject BtnNextLevel;

	public GameObject[] Star;

	public GameController gameController;
	private DataController dataController;

	// Use this for initialization
	void Start () {
		// gameController = FindObjectOfType<GameController> ();
	}
	
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{

		dataController = FindObjectOfType<DataController> ();

		finalScore.text = "Score : " + gameController.score;

		if (dataController.levelSelected == 2) {
			BtnNextLevel.SetActive (false);
		}

		if (gameController.score > 6) {
			Star[0].SetActive(true);
			Star[1].SetActive(true);
			Star[2].SetActive(true);
		} else if (gameController.score > 3) {
			Star[0].SetActive(true);
			Star[1].SetActive(true);			
		} else if (gameController.score <= 3){
			Star[0].SetActive(true);			
		}

		if (gameController.score > 6) {
			if (DataController.instance.categorySelected == 0) {
				PlayerInfo.instance.fruitLevelDone += 1;
				PlayerPrefs.SetInt ("FruitLevel", PlayerInfo.instance.fruitLevelDone);
			} else if (DataController.instance.categorySelected == 1) {
				PlayerInfo.instance.vegetableLevelDone += 1;
				PlayerPrefs.SetInt ("VegetableLevel", PlayerInfo.instance.vegetableLevelDone);
			} else if (DataController.instance.categorySelected == 2) {
				PlayerInfo.instance.animalLevelDone += 1;
				PlayerPrefs.SetInt ("AnimalLevel", PlayerInfo.instance.animalLevelDone);
			}

			dataController.levelSelected += 1;
			dataController.LevelDataSelected = dataController.categoryDataSelected.getCurrentLevelsData (dataController.levelSelected);
			dataController.questions = dataController.LevelDataSelected.questionsData;

		} else {
			BtnNextLevel.SetActive (false);
		}

	}

	public void nextLevel() {
	
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

}
