using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public PlayerState playerState = PlayerState.Idel;
	
	public PlayerIdle playerIdle;
	
	public PlayerWalk playerWalk;

	public AudioClip hurtAudio;
	
	public float speed = 5f;
	
	public bool isShooting = false;
	
	private Rigidbody myRigidBody;

	private float hp = 100f;

	private bool dead = false;

	// Use this for initialization
	void Start () {
		myRigidBody = this.GetComponent<Rigidbody> ();
		playerState = PlayerState.Idel;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
			Dead ();
		//get input
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");
		//handle Left (A) and Right (D) button
		HandleHorizontalBtn (hInput);
		HandleVerticalBtn (vInput);
		ChangePlayerState (hInput,vInput);
		ChangePlayerSpriteByState ();
		SetPlayerDirection ();
	}

	void OnGUI(){
		if (dead) {
			GUI.Box(new Rect(100,100,100,90), "You Die!");
			if(GUI.Button(new Rect(120,140,80,20), "Rerty")) {
				Application.LoadLevel(0);
			}
		}
	}

	private void Dead(){
		dead = true;
	}

	public void TakeDamage(float damage){
		print("takedamage");
		AudioSource.PlayClipAtPoint (hurtAudio, transform.position, 15f);
		hp -= damage;
	}

	private void ChangePlayerState(float hInput,float vInput){
		if (Mathf.Abs (hInput) > 0.05f || Mathf.Abs (vInput) > 0.05f) {
			playerState = PlayerState.Walk;
		} else {
			playerState = PlayerState.Idel;
		}
	}
	
	/// <summary>
	/// Handles the horizontal button.
	/// </summary>
	private void HandleHorizontalBtn(float h){
		Vector3 r = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (h * speed, r.y, 0f);
	}
	
	/// <summary>
	/// Handles the vertical button.
	/// </summary>
	private void HandleVerticalBtn(float v){
		Vector3 r = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (r.x, v * speed, 0f);
	}
	
	/// <summary>
	/// Changes the player sprite.
	/// </summary>
	private void ChangePlayerSpriteByState(){
		switch (playerState) {
		case PlayerState.Idel:
			playerIdle.gameObject.SetActive(true);
			playerWalk.gameObject.SetActive(false);
			break;
		case PlayerState.Walk:
			playerIdle.gameObject.SetActive(false);
			playerWalk.gameObject.SetActive(true);
			break;
		default:
			break;
		}
	}
	
	/// <summary>
	/// Sets the player direction.
	/// </summary>
	private void SetPlayerDirection(){
		float x = 1f;
		if (myRigidBody.velocity.x > 0.05f) {
			x = 1f;
		} else if (myRigidBody.velocity.x < -0.05f) {
			x = -1f;
		} else {
			x = 0;
		}
		if (x != 0) {
			transform.localScale = new Vector3(x,1f,0f);
		}
	}
}