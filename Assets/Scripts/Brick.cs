using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	private int maxHits;
	private int timesHit;

	public Sprite[] hitSprites;

	public static int bricksLeft = 0;

	private bool breakable;
	// Use this for initialization
	void Start () {

		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		maxHits = hitSprites.Length + 1;
		timesHit = 0;
	
		breakable = gameObject.tag.Equals ("Breakable");

		if (breakable) {
			bricksLeft++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {

		if (breakable) {
			HandleHit ();
		}
	}

	void HandleHit() {
		timesHit++;
		
		if (timesHit >= maxHits) {
			bricksLeft--;
			Destroy (gameObject);
			levelManager.OnBrickDestroyed();

		} else {
			int spriteIndex = timesHit - 1;
			gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	// TODO: remove when true win implemented
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
