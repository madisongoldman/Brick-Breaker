using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip breakSound;

	Level level; //cached reference
	GameStatus gameStatus; //cached reference

	private void Start()
	{
		level = FindObjectOfType<Level>();
		gameStatus = FindObjectOfType<GameStatus>();
		level.CountBreakableBlocks();
	}

	private void OnCollisionEnter2D(Collision2D collision2D)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
		FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		gameStatus.AddToScore();
        Destroy(gameObject);
		level.BlockDestroyed();
    }
}
