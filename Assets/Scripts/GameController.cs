using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public DataController dataController;
	public NavigationController navigationController;
	public PlayerController playerController;
	
	[Space(10)]
	public GameObject Question_UI;
	public GameObject Navigation_UI;
	public GameObject GameOver_Panel;
	public GameObject Paused_Panel;
	public GameObject Btn_Fiftyfifty;
	public Text questionTextRenderer;
	public GameObject[] answerGameObjects;
	public GameObject[] pertandaBenarOrSalah;
	public Text displayScore;
	public Text displayTime;
	public Text bantuanTextRenderer;
	public AudioSource correct_S;
	public AudioSource wrong_S;

	[Space(10)]
	public int score;
	public int questionNumberCollided;
	public GameObject objectCollied;

	private float time;
	private int jumlahBantuan = 3;
	[SerializeField]
	private bool isRoundActive;
	private int questionIndex;


	void Awake()
	{
		Time.timeScale = 1;

		if (instance == null) {
			instance = this;
		}
	}

	void Start()
	{
		dataController = FindObjectOfType<DataController> ();
		navigationController = FindObjectOfType<NavigationController> ();
		playerController = FindObjectOfType<PlayerController> ();

		isRoundActive = true;
		score = 0;
		jumlahBantuan = 3;
		questionIndex = 0;
		time = dataController.LevelDataSelected.time;

	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (isRoundActive) {
			if (time > 0) {
				if (questionIndex < 10) {
					time -= Time.deltaTime;
					UpdateTimeRemaining();
				} else {
					isRoundActive = false;
				}
			} else {
				Debug.Log ("Time Up!");
				isRoundActive = false;
			}
		} else {
			Debug.Log("GameOver");
			GameOver();
			
		}
	}

	void UpdateTimeRemaining () {
		displayTime.text = "Time : " + Mathf.Round(time);
	}

	public void showQuestion() {
		Debug.Log("Question Showed");
		foreach (GameObject item in pertandaBenarOrSalah) {
			item.SetActive (false);
		}

		if (jumlahBantuan > 0) {
			Btn_Fiftyfifty.SetActive (true);
		} else {
			Btn_Fiftyfifty.SetActive (false);
		}

		questionTextRenderer.text = dataController.questions[questionNumberCollided].question;
		// Time.timeScale = 0.0000001f * Time.deltaTime;
		
		for (int i = 0; i < answerGameObjects.Length; i++) {
			// answerGameObjects[i].GetComponentInChildren<Text> ().text = dataController.questions[questionNumberCollided].answersData[i].answerText;
			answerGameObjects[i].GetComponent<answerButton>().setup(dataController.questions[questionNumberCollided].answersData[i]);
			answerGameObjects [i].SetActive (true);
		}

		navigationController.unpressed();		
		Navigation_UI.SetActive(false);
		Question_UI.SetActive(true);
	
	}

	public void answerButtonClicked(bool isCorrect) {
		
		StartCoroutine (buttonClicked(isCorrect));
		
	}

	IEnumerator buttonClicked (bool isCorrect) {
		if (isCorrect) {
			score += 1;
			displayScore.text = "Score : " + score.ToString(); 
			Debug.Log ("Benar, Score : " + score);
			correct_S.Play ();
			pertandaBenarOrSalah [0].SetActive (true);
		} else {
			Debug.Log("Salah!");
			wrong_S.Play ();
			pertandaBenarOrSalah [1].SetActive (true);
		}
		questionIndex++;
		yield return new WaitForSeconds (1.0f);
		Destroy(objectCollied);
		Question_UI.SetActive(false);
		resumeGame();
	}
	
	void GameOver () {
		
		if (correct_S.isPlaying || wrong_S.isPlaying) {
			return;
		}

		GameOver_Panel.SetActive(true);
		Navigation_UI.SetActive(false);
		
	}

	public void pauseGame() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}

		Paused_Panel.SetActive(true);
		Navigation_UI.SetActive(false);

	}

	public void resumeGame() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}

		Paused_Panel.SetActive(false);
		Navigation_UI.SetActive(true);
	}

	public void fiftyFifty() {
		
		int x = Random.Range (0, 4);
		int y = Random.Range (0, 4);
		while (y == x) {
			y = Random.Range (0, 4);
		}

		while (answerGameObjects [x].GetComponent<answerButton> ().isCorrect || answerGameObjects [y].GetComponent<answerButton> ().isCorrect) {
			x = Random.Range (0, 4);
			y = Random.Range (0, 4);
			while (y == x) {
				y = Random.Range (0, 4);
			}
		}

		time -= 10;
		jumlahBantuan -= 1;

		answerGameObjects [x].SetActive (false);
		answerGameObjects [y].SetActive (false);

		bantuanTextRenderer.text = jumlahBantuan.ToString ();

		Btn_Fiftyfifty.SetActive (false);

	}

}
