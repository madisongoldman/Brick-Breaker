using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

	//config params
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroyed = 69;
	[SerializeField] TextMeshProUGUI scoreText;

	//state variables
	[SerializeField] int currentScore = 0;
	
	void Start()
	{
		Debug.Log(gameObject);
		scoreText.text = currentScore.ToString();
	}
	// Update is called once per frame
	void Update () {
		Time.timeScale = gameSpeed;
	}

	public void AddToScore() {
		currentScore =+ pointsPerBlockDestroyed;
		scoreText.text = currentScore.ToString();
	}
}
