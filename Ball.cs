using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	//config parameters
	[SerializeField] Paddle paddle1;
	[SerializeField] float velocityX = 2f;
	[SerializeField] float velocityY = 15f;
	[SerializeField] AudioClip[] ballSounds;

	//state
	Vector2 paddleToBallVector;
	bool hasStarted = false;

	//cached component references
	AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasStarted == false) {
			LockBallToPaddle();
			LaunchOnClick();
		}	
	}

	private void LockBallToPaddle() {
		Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePosition + paddleToBallVector;
	}

	private void LaunchOnClick() {
		if (Input.GetMouseButtonDown(0)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
			hasStarted = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (hasStarted) {
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
		}	
	}
}
