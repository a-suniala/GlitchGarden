﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
//		int currentLevel = Application.loadedLevel;
//		if (levelMusicChangeArray[currentLevel]) {
//			AudioSource.PlayClipAtPoint(levelMusicChangeArray[currentLevel], transform.position, 0.2f);
//		}
	}

	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}