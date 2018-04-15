using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSelectLevel : MonoBehaviour {

	public int thisLevel;

	public Sprite enable;
	public Sprite disable;


	void OnEnable () {
		if (DataController.instance.categorySelected == 0) {
			btnLvl (PlayerInfo.instance.fruitLevelDone);
		} else if (DataController.instance.categorySelected == 1) {
			btnLvl (PlayerInfo.instance.vegetableLevelDone);
		} else {
			btnLvl (PlayerInfo.instance.animalLevelDone);
		}
	}


	void btnLvl (int levelterselesaikan) {
		if (levelterselesaikan >= thisLevel) {
			GetComponent<Image> ().sprite = enable;
			GetComponent<Button> ().enabled = true;
			GetComponentInChildren<Text> ().enabled = true;

		} else {
			GetComponent<Image> ().sprite = disable;
			GetComponent<Button> ().enabled = false;
			GetComponentInChildren<Text> ().enabled = false;
		}
	}
}
