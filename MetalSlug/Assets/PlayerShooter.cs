using UnityEngine;
using System.Collections;

public enum ShootDir{
	Left,
	Right,
	Top,
	Down
}

public class PlayerShooter : MonoBehaviour {

	public int shootRate = 7;

	public PlayerGround playerGround;
	public PlayerDown playerDown;
	public PlayerJump playerJump;

	private PlayerMove playerMove;

	private float shootTimeInterval;

	private float timer = 0;

	private bool canShoot = true;

	private bool isTopKeyDown = false;

	private bool isBottomKeyDown = false;

	// Use this for initialization
	void Start () {
		shootTimeInterval = 1.0f / shootRate;
		playerDown = this.GetComponent<PlayerDown> ();
		playerJump = this.GetComponent<PlayerJump> ();
		playerGround = this.GetComponent<PlayerGround> ();
		playerMove = this.GetComponent<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!canShoot) {
			timer += Time.deltaTime;
			if(timer > shootTimeInterval){
				canShoot = true;
				timer -= shootTimeInterval;
			}
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			isTopKeyDown = true;
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			isTopKeyDown = false;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			isBottomKeyDown = true;
		}

		if (Input.GetKeyUp (KeyCode.S)) {
			isBottomKeyDown = false;
		}

		if (canShoot && Input.GetKeyDown (KeyCode.J)) {
			switch(playerMove.playerState){
			case PlayerState.PlayerGround:
				playerGround.Shoot(playerMove.myRigidBody.velocity.x,isTopKeyDown,isBottomKeyDown);
				break;
			case PlayerState.PlayerDown:
				playerDown.Shoot(playerMove.myRigidBody.velocity.x,isTopKeyDown,isBottomKeyDown);
				break;
			case PlayerState.PlayerJump:
				playerJump.Shoot(playerMove.myRigidBody.velocity.x,isTopKeyDown,isBottomKeyDown);
				break;
			}
		}
	}
}
