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
}
