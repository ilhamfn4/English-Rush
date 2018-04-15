using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatGround;

	private bool grounded;
	private bool doubleJump;

	private Animator animator;
	private Rigidbody2D myRgdBody;

	// Use this for initialization
	void Start () {
		myRgdBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatGround);
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.W) && grounded) {
			Jump();
		}

		if (grounded)
			doubleJump = false;

		myRgdBody.velocity = new Vector2 (moveVelocity, myRgdBody.velocity.y);

		// if (Input.GetKey(KeyCode.D)){
		// 	moveRight();
		// }

		// if (Input.GetKey(KeyCode.A)) {
		// 	moveLeft();
		// }

		animator.SetBool("Grounded", grounded);		
		animator.SetFloat("Walking", Mathf.Abs(myRgdBody.velocity.x));
		
		if (myRgdBody.velocity.x > 0) {
			GetComponent<SpriteRenderer>().flipX = false;
		} else if (myRgdBody.velocity.x < 0) {
			GetComponent<SpriteRenderer>().flipX = true;
		}

	}

	public void Jump() {
		
		if (grounded && !doubleJump) {
			myRgdBody.velocity = new Vector2 (myRgdBody.velocity.x, jumpHeight);
			animator.SetTrigger("Jump");
		}

		if (!grounded && !doubleJump) {
			myRgdBody.velocity = new Vector2 (myRgdBody.velocity.x, jumpHeight);
			animator.SetTrigger("Jump");
			doubleJump = true;
		}

	}

}
