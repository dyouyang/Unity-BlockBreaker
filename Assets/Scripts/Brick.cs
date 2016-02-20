using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	private int maxHits;
	private int timesHit;

	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {

		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		maxHits = hitSprites.Length + 1;
		timesHit = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {

		if (gameObject.tag.Equals("Breakable")) {
			HandleHit ();
		}
	}

	void HandleHit() {
		timesHit++;
		
		if (timesHit >= maxHits) {
			Destroy (gameObject);
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
