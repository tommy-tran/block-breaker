using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3 (this.transform.position.x, 0.5f, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp(mousePosInBlocks,0.5f, 15.5f);

		this.transform.position = paddlePos;
	}
}
