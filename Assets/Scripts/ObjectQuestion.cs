using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectQuestion : MonoBehaviour {

	public int questionNumber;
	private DataController dataController;

	// Use this for initialization
	void Start () {
		dataController = FindObjectOfType<DataController> ();

		for (int i=0; i < 10; i++) {
			if (i == questionNumber) {
				GetComponent<SpriteRenderer> ().sprite = dataController.questions[i].questionSprite;
			}
		}

		Destroy (GetComponent<PolygonCollider2D> ());
		gameObject.AddComponent<PolygonCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			GameController.instance.questionNumberCollided = questionNumber;
			GameController.instance.showQuestion();
			GameController.instance.objectCollied = this.gameObject;
		}
	}
}
