using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public AudioClip[] winSounds;
	private int audioIndex = 0;

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Brick.comboIndex = 0;
		Brick.combo = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

}
