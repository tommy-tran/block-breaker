using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	private LevelManager levelManager;
	public int maxHits;
	private int count;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (++count >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites() {
		int spriteIndex = count - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
