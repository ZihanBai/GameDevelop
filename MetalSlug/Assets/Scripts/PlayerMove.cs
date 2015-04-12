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
		//handle bottom (S) button
		HandleSBtn ();

		//handle Left (A) and Right (D) button
		Vector3 v = HandleHorizontalBtn ();

		//Ray for knowing player is ground or not
		bool playerIsGround = PlayerIsGround ();

		//set PalyerState
		SetPlayerState (playerIsGround,isBottomBtnClick);

		//Press K to Jump
		if(playerIsGround)
			HandleJump (v);
		//change active gameobject by playerstate
		ChangeActiveGameObjectByPlayerState (playerState);
		//player direction
		SetPlayerDirection ();
		//change player idle or walk
		if (Mathf.Abs (myRigidBody.velocity.x) > 0.05f) {
			playerGround.status = AnimStatus.Walk;
			playerDown.status = AnimStatus.Walk;
		} else {
			playerGround.status = AnimStatus.Idel;
			playerDown.status = AnimStatus.Idel;
		}
	}

	/// <summary>
	/// Handles the jump.
	/// </summary>
	/// <param name="v">V.</param>
	private void HandleJump(Vector3 v){
		if (Input.GetKeyDown (KeyCode.K)) {
			myRigidBody.velocity = new Vector3(v.x,jumpSpeed,v.z);
		}
	}

	/// <summary>
	/// Players the is ground.
	/// </summary>
	/// <returns><c>true</c>, if is ground was playered, <c>false</c> otherwise.</returns>
	private bool PlayerIsGround(){
		RaycastHit hitInfo;
		return Physics.Raycast (transform.position + Vector3.up * 0.1f, Vector3.up, out hitInfo,2.8f,groundLayerMask);
	}

	/// <summary>
	/// Changes the state of the active game object by player.
	/// </summary>
	/// <param name="playerState">Player state.</param>
	private void ChangeActiveGameObjectByPlayerState(PlayerState playerState){
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

	/// <summary>
	/// Handles the S button.
	/// </summary>
	private void HandleSBtn(){
		if (Input.GetKeyDown (KeyCode.S)) {
			isBottomBtnClick = true;
		}
		
		if (Input.GetKeyUp (KeyCode.S)) {
			isBottomBtnClick = false; 
		}
	}

	/// <summary>
	/// Handles the horizontal button.
	/// </summary>
	private Vector3 HandleHorizontalBtn(){
		float h = Input.GetAxis ("Horizontal");
		Vector3 v = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (h * speed, v.y, v.z);
		v = myRigidBody.velocity;
		return v;
	}

	/// <summary>
	/// Sets the state of the player.
	/// </summary>
	/// <param name="isGround">true for player is stand ground</param>
	/// <param name="isBottomBtnClick">true for bottom button down.</param>
	private void SetPlayerState(bool isGround,bool isBottomBtnClick){
		if (isGround) {
			if (isBottomBtnClick) {
				playerState = PlayerState.PlayerDown;
			} else {
				playerState = PlayerState.PlayerGround; 
			}
		} else {
			playerState = PlayerState.PlayerJump;
		}
	}

	/// <summary>
	/// Sets the player direction.
	/// </summary>
	private void SetPlayerDirection(){
		float x = 1;
		if (myRigidBody.velocity.x > 0.05f) {
			x = -1;
		} else if (myRigidBody.velocity.x < -0.05f) {
			x = 1;
		} else {
			x = 0;
		}
		if (x != 0) {
			playerGround.transform.localScale = new Vector3(x,1,1);
			playerDown.transform.localScale = new Vector3(x,1,1);
			playerJump.transform.localScale = new Vector3(x,1,1);
		}
	}

}
