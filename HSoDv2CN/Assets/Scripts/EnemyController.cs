using UnityEngine;
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

	public float attack = 0f;
	
	/// <summary>
	/// The hurt audio.
	/// </summary>
	private AudioSource hurtAudio;

	private float attackRate = 1f;
	
	private float attackTimer = 0f;
	
	private float attackInterval = 0f;

	void Awake(){
		attackInterval = 1 / attackRate;
		attack = 5f;
		hurtAudio = this.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (this.hp <= 0) {
			Dead();
		}
		Vector3 targetPositon = player.gameObject.transform.position;
		Vector3 distance = targetPositon - transform.position;
		if (enemyState != EnemyState.Die) {
			if (Mathf.Abs (distance.magnitude) > 7f) {
				enemyState = EnemyState.Walk;
				transform.position = Vector3.Lerp(transform.position,targetPositon,0.5f*Time.deltaTime);
			}else if(Mathf.Abs (distance.magnitude) < 7f){
				enemyState = EnemyState.Attack;
				Attack(attack);
			}
		}
//		print ("*******" + enemyState);
		ChangeEnemySpriteByState ();
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

	private void Attack(float attack){
		attackTimer += Time.deltaTime;
		if(attackTimer > attackInterval){
			attackTimer -= attackInterval;
			player.TakeDamage(attack);
		}
	}

	private void DestroyEnemy(){
		Destroy (this.gameObject);
	}

	/// <summary>
	/// Enemy Dead.
	/// </summary>
	private void Dead(){
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
