using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GUIText scoreText;
	private int score;

    public bool gameOver;

	public GameObject[] planetPrefabs;

	public Vector3 spawnValues;
	public int planetCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		score = 0;
        UpdateScore();

        gameOver = false;

		StartCoroutine(SpawnNext());


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	public void UpdateScore()
	{
		scoreText.text = "Score: " + score;
		Debug.Log("Score:" + score);
	}

	IEnumerator SpawnNext()
	{

		yield return new WaitForSeconds(startWait);
		while (true) {
			for (int i = 0; i < planetCount; i++)
			{
				//SPAWNING PLANETS
				int planetIndex = Random.Range(0, planetPrefabs.Length);
				GameObject planetPrefabToSpawn = planetPrefabs[planetIndex];

				//SETTING POSITION
				GameObject newPlanet = Instantiate(planetPrefabToSpawn, new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z), Quaternion.identity);

				//Quaternion spawnRotation = Quaternion.identity;
				yield return new WaitForSeconds(spawnWait);

				//SETTING SPEED FOR PLANETS
				newPlanet.GetComponent<PlanetPrefabMovement>().SettingVelocity();
			}

			yield return new WaitForSeconds(waveWait);

			if (gameOver)
			{
                break;
			}

		}
	}

    public void GameOver () {

        gameOver = true; 

        SceneManager.LoadScene("SplashScene", LoadSceneMode.Additive); 
    }

 }

