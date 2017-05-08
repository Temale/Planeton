using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSoundManager : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		//starPrefabAudioSource = gameObject.GetComponent<AudioSource> ();

		GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

		if(gameManagerObject != null) {
			gameManager = gameManagerObject.GetComponent<GameManager>();
		}
		if(gameManager == null) {
			Debug.Log("Cannot find 'GameManager' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Shredder") {	
			Destroy (gameObject);

		}

		if (other.tag == "Player") {
				
			Destroy (gameObject);

		}
	}
}
