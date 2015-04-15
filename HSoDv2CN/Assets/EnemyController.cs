﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	/// <summary>
	/// The hp.
	/// </summary>
	public float hp = 100f;

	public EnemyState enemyState = EnemyState.Idel;

	public EnemyIdle enemyIdle;

	public EnemyWalk enemyWalk;

	public EnemyAttack enemyAttack;

	public EnemyDie enemyDie;

	public PlayerController player;

	/// <summary>
	/// The death audio.
	/// </summary>
	public AudioClip deathAudio;

	/// <summary>
	/// The hurt audio.
	/// </summary>
	private AudioSource hurtAudio;

	void Awake(){
		hurtAudio = this.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (this.hp <= 0) {
			Dead();
		}
		Vector3 distance = player.gameObject.transform.position - transform.position;
		if (enemyState != EnemyState.Die) {
			if (Mathf.Abs (distance.magnitude) > 7f) {
				enemyState = EnemyState.Walk;
			}else{
				enemyState = EnemyState.Attack;
			}
		}

		ChangeEnemySpriteByState ();
	}

	private void DestroyEnemy(){
		Destroy (this.gameObject);
	}

	public void TakeDamage(float damage){
		if (this.hp <= 0f)
			return;
		hurtAudio.Play ();
		this.hp -= damage;
		if (this.hp <= 0f) {
			Dead();
		}
	}

	/// <summary>
	/// Enemy Dead.
	/// </summary>
	private void Dead(){
		AudioSource.PlayClipAtPoint (deathAudio, transform.position, 0.5f);
		enemyState = EnemyState.Die;
		Invoke ("DestroyEnemy", 1.5f);
	}

	private void ChangeEnemySpriteByState(){
		switch (enemyState) {
		case EnemyState.Idel:
			enemyIdle.gameObject.SetActive(true);
			enemyWalk.gameObject.SetActive(false);
			enemyAttack.gameObject.SetActive(false);
			enemyDie.gameObject.SetActive(false);
			break;
		case EnemyState.Walk:
			enemyIdle.gameObject.SetActive(false);
			enemyWalk.gameObject.SetActive(true);
			enemyAttack.gameObject.SetActive(false);
			enemyDie.gameObject.SetActive(false);
			break;
		case EnemyState.Attack:
			enemyIdle.gameObject.SetActive(false);
			enemyWalk.gameObject.SetActive(false);
			enemyAttack.gameObject.SetActive(true);
			enemyDie.gameObject.SetActive(false);
			break;
		case EnemyState.Die:
			enemyIdle.gameObject.SetActive(false);
			enemyWalk.gameObject.SetActive(false);
			enemyAttack.gameObject.SetActive(false);
			enemyDie.gameObject.SetActive(true);
			break;
		}
	}
}
