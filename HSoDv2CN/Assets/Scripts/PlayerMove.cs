using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public PlayerState playerState = PlayerState.Idel;

	public LeftHandController leftHand;

	public float speed = 5f;

	public bool isShooting = false;

	private Rigidbody myRigidBody;



	// Use this for initialization
	void Start () {
		myRigidBody = this.GetComponent<Rigidbody> ();
		playerState = PlayerState.Idel;
	}
	
	// Update is called once per frame
	void Update () {
		//get input
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");
		//handle Left (A) and Right (D) button
		HandleHorizontalBtn (hInput);
		HandleVerticalBtn (vInput);
		ChangePlayerState (hInput,vInput);
		ChangePlayerSpriteByState ();
	}

	private void ChangePlayerState(float hInput,float vInput){
		if (isShooting) {
			playerState = PlayerState.Shooting;
			return;
		}
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
		myRigidBody.velocity = new Vector3 (h * speed, r.y, r.z);
		if (Mathf.Abs (h) > 0f)
			playerState = PlayerState.Walk;
	}

	/// <summary>
	/// Handles the vertical button.
	/// </summary>
	private void HandleVerticalBtn(float v){
		Vector3 r = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (r.x, v * speed, r.z);
		if (Mathf.Abs (v) > 0.05f)
			playerState = PlayerState.Walk;
	}
	
	/// <summary>
	/// Changes the player sprite.
	/// </summary>
	private void ChangePlayerSpriteByState(){
		switch (playerState) {
		case PlayerState.Idel:
			leftHand.DownForIdle();
			break;
		case PlayerState.Walk:
			leftHand.UpForShoot();
			break;
		case PlayerState.Shooting:
			leftHand.UpForShoot();
			break;
		default:
			break;
		}
	}
}
