using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private Vector3 paddleToBallVector;

	bool gameStarted = false;

	// Use this for initialization
	void Start () {

		paddle = GameObject.FindObjectOfType<Paddle> ();
		// Save the relative position of ball to paddle
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameStarted) {

			// Keep ball sticky
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Launch ball.
			if (Input.GetMouseButtonDown(0)) {
				this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				gameStarted = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (gameStarted) {
			gameObject.GetComponent<AudioSource> ().Play ();

			// Apply random bounce to prevent boring loops
			Vector2 randomBounce = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 0.2f));
			GetComponent<Rigidbody2D>().velocity += randomBounce;
		}

	}
}
