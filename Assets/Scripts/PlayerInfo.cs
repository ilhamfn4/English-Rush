using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public static PlayerInfo instance;

	public int fruitLevelDone = 1;
	public int vegetableLevelDone = 1;
	public int animalLevelDone = 1;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if (instance == null) {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		

	}

	void Update() {
		if (!PlayerPrefs.HasKey("FruitLevel") && !PlayerPrefs.HasKey("VegetableLevel") && !PlayerPrefs.HasKey("AnimalLevel")) {
			PlayerPrefs.SetInt("FruitLevel", 1);
			PlayerPrefs.SetInt("VegetableLevel", 1);
			PlayerPrefs.SetInt("AnimalLevel", 1);
		} else {
			if (PlayerPrefs.GetInt ("FruitLevel") > 3) {
				fruitLevelDone = 3;
			} else {
				fruitLevelDone = PlayerPrefs.GetInt ("FruitLevel");
			}

			if (PlayerPrefs.GetInt ("VegetableLevel") > 3) {
				vegetableLevelDone= 3;
			} else {
				vegetableLevelDone = PlayerPrefs.GetInt ("VegetableLevel");
			}

			if (PlayerPrefs.GetInt ("AnimalLevel") > 3) {
				animalLevelDone = 3;
			} else {
				animalLevelDone = PlayerPrefs.GetInt ("AnimalLevel");
			}
		}
	}

}