using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	/// <summary>
	/// The hp.
	/// </summary>
	public float hp = 100f;

	/// <summary>
	/// The animator.
	/// </summary>
	private Animator animator;

	/// <summary>
	/// The player move.
	/// </summary>
	private PlayerMove playerMove;

	private PlayerShoot playerShoot;

	/// <summary>
	/// The body renderer.
	/// </summary>
	private SkinnedMeshRenderer bodyRenderer;

	/// <summary>
	/// The smoothing.
	/// </summary>
	private float smoothing = 3f;

	void Awake(){
		animator = this.GetComponent<Animator> ();
		playerMove = this.GetComponent<PlayerMove> ();
		playerShoot = this.GetComponentInChildren<PlayerShoot> ();
		bodyRenderer = transform.Find ("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;
	}

	void FixedUpdate(){
		if (Input.GetMouseButtonDown (0)) {
			TakeDamage(30f);
		}
	}

	void Update(){
		bodyRenderer.material.color = Color.Lerp (bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
	}

	public void TakeDamage(float damage){
//		print("TakeDamage");
		if(hp <= 0f) return;
		hp -= damage;
		bodyRenderer.material.color = Color.red;
		if (hp <= 0f) {
			Dead();
		}

	}

	private void Dead(){
		animator.SetBool ("Dead", true);
		this.playerMove.enabled = false;
		this.playerShoot.enabled = false;
	}
}
