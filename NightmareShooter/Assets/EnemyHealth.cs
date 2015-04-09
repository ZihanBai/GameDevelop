using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private float hp = 100f;
	private Animator anim;
	private NavMeshAgent agent;
	private EnemyMove enemyMove;
	private CapsuleCollider capCollider;
	private AudioSource hurtAudio;

	public AudioClip deathAudio;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		enemyMove = this.GetComponent<EnemyMove> ();
		capCollider = this.GetComponent<CapsuleCollider> ();
		hurtAudio = this.GetComponent<AudioSource> ();
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
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		enemyMove.enabled = false;
		capCollider.enabled = false;
		AudioSource.PlayClipAtPoint (deathAudio, transform.position, 0.5f);
	}
}
