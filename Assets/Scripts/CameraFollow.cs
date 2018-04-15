using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private float xMax;
	[SerializeField]	
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;
	[SerializeField]
	private float xOffSet;
	[SerializeField]
	private float yOffSet;

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
	}
	
	void LateUpdate()
	{
		transform.position = new Vector3 (Mathf.Clamp(player.position.x, xMin, xMax) + xOffSet, Mathf.Clamp(player.position.y , yMin, yMax) + yOffSet, transform.position.z);
	}
}
