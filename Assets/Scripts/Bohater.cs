using UnityEngine;
using System.Collections;

public class Bohater : MonoBehaviour {
    private bool doubleJump;
    public float speedMove;
    public float jumpHeight;
    public bool grounded;
	public bool stoi;
    public LayerMask WhatIsGround;
    private Rigidbody2D myRigidBody;
    private Collider2D myCollider;
	private AudioSource audio;
    // Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
		audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers (myCollider, WhatIsGround);

		if (grounded)
			doubleJump = false;

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) && grounded == true) {
			myRigidBody.velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			doubleJump = true;
		}

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) && grounded == false && doubleJump == true) {
			myRigidBody.velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 2 * jumpHeight);
			doubleJump = false;
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			myRigidBody.velocity = new Vector2 (speedMove, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			myRigidBody.velocity = new Vector2 (-speedMove, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (grounded && !stoi){
			audio.Play();
			stoi = true;
		}
		if (!grounded){
			stoi = false;
		}
	}
}