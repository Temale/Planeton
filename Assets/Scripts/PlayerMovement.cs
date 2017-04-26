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
	public int scoreValue;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();

		GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
		if(gameManagerObject != null) {
			gameManager = gameManagerObject.GetComponent<GameManager>();
		}
		if(gameManager == null) {
			Debug.Log("Cannot find 'GameManager' script");
		}
			
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

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Stars") { 
			gameManager.AddScore(scoreValue);
			Destroy (other.gameObject);


//			gameObject.GetComponent <GameManager>().AddScore(scoreValue);
//			Score sn = gameObject.GetComponent<ScriptName>() sn.DoSomething();
		}
	}
	
}