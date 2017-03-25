using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject boss;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	public AudioSource backgroundMusic;
	public AudioSource deathMusic;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	public void GameOver() {
		gameOverText.text = "You Died";
		gameOver = true;
		backgroundMusic.Stop ();
		deathMusic.Play ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i <= hazardCount; i++) {
				
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, getRandomPosition(), spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			Instantiate (boss, getRandomPosition(), Quaternion.identity);
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}

	public Vector3 getRandomPosition()
	{
		return new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
	}

	public void addScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}

		}
	}
}
