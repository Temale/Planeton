using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {

	public GameObject[] planetPrefabs;
	public float interval ;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNext", 0, interval);
	}

	void Update () {
		
		interval = Random.Range (1f, 5f); 
	}

	public void SpawnNext() {
		
		int planetIndex = Random.Range (0, planetPrefabs.Length); 
		GameObject planetPrefabToSpawn =planetPrefabs [planetIndex];

		GameObject newPlanet = Instantiate (planetPrefabToSpawn, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) ; 

		newPlanet.GetComponent <PlanetPrefabMovement> ().SettingVelocity (); 
	
	}
}
