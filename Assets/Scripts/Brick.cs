using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	public int maxHits;
	private int timesHit;

	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {

		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		timesHit = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		timesHit++;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			int spriteIndex = timesHit - 1;
			gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		//SimulateWin ();
	}

	// TODO: remove when true win implemented
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
