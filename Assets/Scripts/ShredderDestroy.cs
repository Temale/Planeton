using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderDestroy : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Stars") {	
			Destroy (other.gameObject);
		}
	}
}

