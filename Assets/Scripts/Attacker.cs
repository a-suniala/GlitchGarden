﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Health))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {

	}

	public void setSpeed (float speed) {
		currentSpeed = speed;
	}

	// Called from the animator at the time of actual blow
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}

	}

	public void Attack (GameObject target) {
		currentTarget = target;
	}

}
