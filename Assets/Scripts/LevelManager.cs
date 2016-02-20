using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("level load requested for " + name);
		Application.LoadLevel (name);
	}

	public void LoadNextLevel ()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void OnBrickDestroyed ()
	{
		if (Brick.bricksLeft <= 0) {
			LoadNextLevel();
		}
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
