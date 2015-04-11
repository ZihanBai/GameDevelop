using UnityEngine;
using System.Collections;

public enum PlayerState{
	PlayerGround,		//Normal
	PlayerJump,			//Jump
	PlayerDown			//Down
}

public class PlayerMove : MonoBehaviour {
	
	public float speed = 3f;

	public float jumpSpeed = 3f;

	public PlayerState playerState = PlayerState.PlayerGround;

	public PlayerGround playerGround;

	public PlayerDown playerDown;

	public PlayerJump playerJump;

	private bool isGround = false;

	private int groundLayerMask;

	private Rigidbody myRigidBody;

	private bool isBottomBtnClick = false;

	// Use this for initialization
	void Start () {
		myRigidBody = this.GetComponent<Rigidbody> ();
		groundLayerMask = LayerMask.GetMask ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			isBottomBtnClick = true;
		}

		if (Input.GetKeyUp (KeyCode.S)) {
			isBottomBtnClick = false; 
		}

		float h = Input.GetAxis ("Horizontal");
		Vector3 v = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (h * speed, v.y, v.z);
		v = myRigidBody.velocity;

		//Ray for knowing player is ground or not
		RaycastHit hitInfo;
		isGround = Physics.Raycast (transform.position + Vector3.up * 0.1f, Vector3.up, out hitInfo,2.8f,groundLayerMask);
		//get PalyerState
		if (!isGround) {
			playerState = PlayerState.PlayerJump;
		} else {
			if(isBottomBtnClick){
				playerState = PlayerState.PlayerDown;
			}else{
				playerState = PlayerState.PlayerGround; 
			}
		}

		//Press K to Jump
		if (isGround && Input.GetKeyDown (KeyCode.K)) {
			myRigidBody.velocity = new Vector3(v.x,jumpSpeed,v.z);
		}

		switch (playerState) {
		case PlayerState.PlayerDown:
			playerDown.gameObject.SetActive(true);
			playerGround.gameObject.SetActive(false);
			playerJump.gameObject.SetActive(false);
			break;
		case PlayerState.PlayerGround:
			playerDown.gameObject.SetActive(false);
			playerGround.gameObject.SetActive(true);
			playerJump.gameObject.SetActive(false);
			break;
		case PlayerState.PlayerJump:
			playerDown.gameObject.SetActive(false);
			playerGround.gameObject.SetActive(false );
			playerJump.gameObject.SetActive(true);
			break;
		}

	}
}
