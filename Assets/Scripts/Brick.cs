using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip[] comboList;
	public static int combo = 0;
	public static int comboIndex = 0;
	public GameObject smoke;

	private LevelManager levelManager;
	private int count;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = FindObjectOfType<LevelManager> ();
		count = 0;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collider) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}

	}

	void HandleHits () {
		int maxHits = hitSprites.Length + 1;
		if (++count >= maxHits) {
			breakableCount--;
			if (++combo >= 3) {
				combo = 0;
				AudioSource.PlayClipAtPoint (comboList [comboIndex++], transform.position);
			}
			if (comboIndex >= comboList.Length) {
				comboIndex = 0;
			}
			levelManager.BrickDestroyed ();
			GameObject particles = Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
			particles.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites() {
		int spriteIndex = count - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
