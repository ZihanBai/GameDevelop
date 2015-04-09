using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	/// <summary>
	/// The hp.
	/// </summary>
	public float hp = 100f;

	/// <summary>
	/// The animation.
	/// </summary>
	private Animator anim;

	/// <summary>
	/// The agent.
	/// </summary>
	private NavMeshAgent agent;

	/// <summary>
	/// The enemy move.
	/// </summary>
	private EnemyMove enemyMove;

	/// <summary>
	/// The enemy attack.
	/// </summary>
	private EnemyAttack enemyAttack;

	/// <summary>
	/// The cap collider.
	/// </summary>
	private CapsuleCollider capCollider;

	/// <summary>
	/// The hurt audio.
	/// </summary>
	private AudioSource hurtAudio;

	/// <summary>
	/// The parti system.
	/// </summary>
//	private ParticleSystem partiSystem;

	/// <summary>
	/// The death audio.
	/// </summary>
	public AudioClip deathAudio;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		enemyMove = this.GetComponent<EnemyMove> ();
		enemyAttack = this.GetComponent<EnemyAttack> ();
		capCollider = this.GetComponent<CapsuleCollider> ();
		hurtAudio = this.GetComponent<AudioSource> ();
//		partiSystem = this.GetComponent<ParticleSystem> ();
	}

	void Update(){
		if (this.hp <= 0) {
			DisAppear();
		}
	}

	private void DisAppear(){
		transform.Translate (Vector3.down * Time.deltaTime * 0.5f);
		if (transform.position.y <= -2f) {
			Destroy(this.gameObject);
		}
	}

	public void TakeDamage(float damage,Vector3 hitPoint){
		if (this.hp <= 0f)
			return;
		hurtAudio.Play ();
//		partiSystem.transform.position = hitPoint;
//		partiSystem.Play ();
		this.hp -= damage;
		if (this.hp <= 0f) {
			Dead();
		}
	}

	/// <summary>
	/// Enemy Dead.
	/// </summary>
	private void Dead(){
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		enemyMove.enabled = false;
		enemyAttack.enabled = false;
		capCollider.enabled = false;
		AudioSource.PlayClipAtPoint (deathAudio, transform.position, 0.5f);
	}
}
