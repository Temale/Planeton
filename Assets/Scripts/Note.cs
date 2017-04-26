//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	public AudioClip SoundToPlay;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider otherObj)
	{
		if (otherObj.tag == "Player")
		{
			print ("played note");
			audio.PlayOneShot(SoundToPlay, Volume);
			alreadyPlayed = true;
		}
	}
}

