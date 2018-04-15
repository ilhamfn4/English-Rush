using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour {

	public Sprite enable;
	public Sprite disable;

	public GameObject BGM;

	private Text TxtM;
	// Use this for initialization
	void Start () {
		try {
			BGM = GameObject.Find("BGM");
			TxtM = GameObject.Find("TxtM").GetComponent<Text> ();
	
		} catch {}
	}
	
	void pauseBGM () {
		BGM.GetComponent<AudioSource> ().Pause();
		GetComponent<Image> ().sprite = disable;
	}
	
	void playBGM() {
		BGM.GetComponent<AudioSource> ().Play();
		GetComponent<Image> ().sprite = enable;
	}

	public void handle () {
		if (BGM.GetComponent<AudioSource> ().isPlaying) {
			if (TxtM != null) {
				TxtM.text = "Music Off";
			}
			pauseBGM();
		} else {
			if (TxtM != null) {
				TxtM.text = "Music On";
			}
			playBGM();
		}
	}

}
