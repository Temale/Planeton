﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyPlayer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Destroy (other.gameObject); 
		}

		if (other.tag == "Shredder") {
			Destroy (gameObject); 
		}
	
	}

}
