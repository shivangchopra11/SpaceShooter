using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText,gameOverText,restartText;﻿
	private bool gameOver, restart;
	private int score;
	void Update()
	{
		if (restart==true && Input.GetTouch (0).phase == TouchPhase.Began) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
	void Start() {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while(true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				int index = Random.Range(0,2);
				Instantiate (hazards[index], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Tap to restart";
				restart = true;
				break;
			}
		}


	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	public void GameOver() 
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
