using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSoundManager : MonoBehaviour {

	AudioSource starPrefabAudioSource; 

	//Star Audio Clips
	public AudioClip starCollisionOne; 
	public AudioClip starCollisionTwo;
	public AudioClip starCollisionThree;
	public AudioClip starCollisionFour; 
	public AudioClip starCollisionFive; 


	// Use this for initialization
	void Start () {
		starPrefabAudioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {

			starPrefabAudioSource.clip = starCollisionOne;

			print ("HEWY");

			if (transform.position.y >= 3.5f) {
				starPrefabAudioSource.clip = starCollisionOne;
				starPrefabAudioSource.Play (); 
				//starCollisionOne.Play();
				print ("HEY");
			}
			if (transform.position.y >= 1.5f) {
				starPrefabAudioSource.clip = starCollisionTwo;
				starPrefabAudioSource.Play (); 
			}

		}
	}
}
