﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock ball relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a left mouse click to launch
			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse button is clicked");
				hasStarted = true;

				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1.5f , 10f);
			}
		}
			
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
		Vector2 speed = new Vector2 (0, 0.03f);

		if (this.GetComponent<Rigidbody2D> ().velocity.y < 0) {
			this.GetComponent<Rigidbody2D> ().velocity -= speed;
		} else {
			this.GetComponent<Rigidbody2D> ().velocity += speed;
		}

		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}

	}
}
