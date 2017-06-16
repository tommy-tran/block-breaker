using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserColider : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("Lose Screen");
		Brick.breakableCount = 0;
		Brick.comboIndex = 0;
		Brick.combo = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}

}
