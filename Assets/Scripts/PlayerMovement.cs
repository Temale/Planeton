using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public float yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Boundary boundary;
	public float CometSpeed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {


		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2d.AddForce (Vector2.up * CometSpeed);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			rb2d.AddForce (Vector2.down * CometSpeed);

		}

		//powerups
		if (Input.GetKeyDown (KeyCode.Space)) {

		}

		//        float moveVertical = Input.GetAxis(“Vertical”);

		//        Vector2 movement = new Vector2(0.0f, moveVertical);
		//        rb.velocity = movement * speed;
		 
		rb2d.position = new Vector2( rb2d.position.x, Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax) );

	}
}