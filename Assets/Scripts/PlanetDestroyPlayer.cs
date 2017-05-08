using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyPlayer : MonoBehaviour {

	private GameManager gameManager;

	public AudioSource planetAudioSource; 

	public AudioClip planetCollision; 

    void Start (){
		GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

		if (gameManagerObject != null)
		{
			gameManager = gameManagerObject.GetComponent<GameManager>();
		}
		if (gameManager == null)
		{
			Debug.Log("Cannot find 'GameManager' script");
		}
    }

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {

            planetAudioSource.clip = planetCollision;
			planetAudioSource.Play();

            Destroy (other.gameObject);

            gameManager.GameOver();


		}

		if (other.tag == "Shredder") {
			Destroy (gameObject); 
		}
	
	}

}
