using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerButton : MonoBehaviour {

	public bool isCorrect;
	private AnswersData answerData;
	[SerializeField]
	private Sprite defaultBtnSprite;
	
	public void setup(AnswersData data) {
		answerData = data;
		isCorrect = answerData.isCorrect;
		if (answerData.answerSprite != null) {			
			GetComponent<Image> ().sprite = answerData.answerSprite;
			GetComponentInChildren<Text>().text = string.Empty;	

		} else {
			
			GetComponent<Image> ().sprite = defaultBtnSprite;
			GetComponentInChildren<Text>().text = answerData.answerText;	
		}
	}

	public void handleClick() {
		GameController.instance.answerButtonClicked(answerData.isCorrect);
		// GameController.instance.Question_UI.SetActive(false);
		// Destroy(gameObject);
	}

}
