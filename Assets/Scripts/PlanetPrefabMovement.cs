using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPrefabMovement : MonoBehaviour {

	float rangeX;
	Vector3 velocity; 

	// Use this for initialization
	void Start () {
		
	}

	public void SettingVelocity () {
		rangeX = Random.Range (-0.09f, -0.9f); 

		velocity = new Vector3 (rangeX, 0f, 0f); 

		transform.Translate (velocity); 
	}


}
