﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public int scoreValue;
	private GameController gameController;
	public GameObject playerExplosion;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
		if (gameController == null)
			Debug.Log ("Can't find game controller"); 
			
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary")
			return;
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
			
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
