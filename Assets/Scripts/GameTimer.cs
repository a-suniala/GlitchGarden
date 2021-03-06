﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelPlayTimeSeconds = 100f;

	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLabel;
	private bool endOfLevel = false;
	
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		winLabel = GameObject.Find ("WinLabel");
		if (!winLabel) Debug.LogWarning ("Please create UI Text child for LevelCanvas called 'WinLabel'");
		winLabel.SetActive(false);
	}

	void Update () {
		slider.value = 1 - (Time.timeSinceLevelLoad / levelPlayTimeSeconds);
		if (Time.timeSinceLevelLoad >= levelPlayTimeSeconds && !endOfLevel) {
			LevelSuccess();
		}
	}

	void LevelSuccess() {
		DestroyAllTaggedObjects();
		endOfLevel = true;
		audioSource.Play();
		winLabel.SetActive(true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}

	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}

	void DestroyAllTaggedObjects () {
		GameObject[] destroyables = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject destroyable in destroyables) {
			Destroy (destroyable);
		}
	}
}
