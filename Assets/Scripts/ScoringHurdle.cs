﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringHurdle : MonoBehaviour {

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player")) {
			scoreManager.AddScore (Random.Range(0, 10));
		}
	}
}
