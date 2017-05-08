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

	public AudioSource starPrefabAudioSource;

	//Star Audio Clips
	public AudioClip starCollisionOne;
	public AudioClip starCollisionTwo;
	public AudioClip starCollisionThree;
	public AudioClip starCollisionFour;
	public AudioClip starCollisionFive;

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

            if (other.transform.position.y >= 3f)
            {
                starPrefabAudioSource.clip = starCollisionOne;
                starPrefabAudioSource.Play();
                //starCollisionOne.Play();
                print("I'M COLLISION ONE");
            }

            if (other.transform.position.y >= 1.5f && other.transform.position.y < 3f){
                starPrefabAudioSource.clip = starCollisionTwo;
                starPrefabAudioSource.Play();

                print("I'M COLLISION TWO");
            }

            if (other.transform.position.y > -1.5f && other.transform.position.y < 1.5f){
                starPrefabAudioSource.clip = starCollisionThree;
                starPrefabAudioSource.Play();

                print("I'M COLLISION THREE");
            }

            if (other.transform.position.y <= -1.5f && other.transform.position.y > -3f){
                starPrefabAudioSource.clip = starCollisionFour;
                starPrefabAudioSource.Play();

                print("I'M COLLISION FOUR");
            }

            if (other.transform.position.y <= -3f){
                starPrefabAudioSource.clip = starCollisionFive;
                starPrefabAudioSource.Play();

                print("I'M COLLISION FIVE");
            }

		}
	}
	
}