using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Paddle paddle;

	private bool hasStarted = false;

	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
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

				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f , 10f);
			}
		}
			
	}
}
