﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
	[SerializeField] int breakableBlocks; //serialized for debugging purposes
	SceneLoader sceneLoader; //cache reference

	private void Start()
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void CountBreakableBlocks() {
		breakableBlocks++;
	}

	public void BlockDestroyed() {
		breakableBlocks--;

		if (breakableBlocks <= 0) {
			sceneLoader.LoadNextScene();
		}
	}
}
