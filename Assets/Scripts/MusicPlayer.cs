using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	// Use this for initialization
	void Awake () {
		Scene scene = SceneManager.GetActiveScene ();

		if (GetComponent<AudioSource> () != null) {
			AudioSource audio = GetComponent<AudioSource> ();
			if ((scene.name == "Win Screen") && (GetComponent<AudioSource>().name == "cdonoken")) {
				print ("WIN");
				instance = this;
				GameObject.DontDestroyOnLoad (gameObject);
			}
			else if ((scene.name == "Start Menu") && (GetComponent<AudioSource>().name == "victory_fanfare")) {
				print ("LOSE");
				instance = this;
				GameObject.DontDestroyOnLoad (gameObject);			
			}

		} else if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
