﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Health))]
public class Defender : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (name + " trigger entered by " + collider);
	}

}
