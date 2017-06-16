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
		if (audioIndex == winSounds.Length)
			audioIndex = 0;
		if ((Application.loadedLevel + 1) == 4) {
			AudioSource.PlayClipAtPoint (winSounds [audioIndex++], transform.position);
		}
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

}
