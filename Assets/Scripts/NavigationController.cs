using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour {

	private PlayerController player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	public void moveRight() {
		Move(1f);
	}

	public void moveLeft() {
		Move(-1f);
	}

	public void unpressed() {
		Move(0);
	}

	public void jump() {
		player.Jump();
	}

	private void Move(float inputMove) {
		player.moveVelocity = player.moveSpeed * inputMove;
	}
}
