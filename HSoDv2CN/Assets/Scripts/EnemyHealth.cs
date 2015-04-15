using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	/// <summary>
	/// The hp.
	/// </summary>
	public float hp = 100f;

	/// <summary>
	/// The death audio.
	/// </summary>
	public AudioClip deathAudio;

	public EnemyIdle enemyIdle;

	public EnemyDie enemyDie;

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
	}

	private void DestroyEnemy(){
		Destroy (this.gameObject);
	}

	/// <summary>
	/// Enemy Dead.
	/// </summary>
	private void Dead(){
		AudioSource.PlayClipAtPoint (deathAudio, transform.position, 0.5f);
		enemyIdle.gameObject.SetActive (false);
		enemyDie.gameObject.SetActive (true);
		Invoke ("DestroyEnemy", 0.5f);
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
}
