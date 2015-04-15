using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public int shootRate = 7;

	private float timer = 0;

	private float shootTimeInterval;

	private bool canShoot = true;

	private PlayerController playerController;

	public PlayerIdle playerIdle;

	public PlayerWalk playerWalk;

	// Use this for initialization
	void Start () {
		shootTimeInterval = 1.0f / shootRate;
		playerController = this.GetComponent<PlayerController> ();
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
		HandleShootBtn ();
	}

	private void ShootFinish(){
	}

	/// <summary>
	/// Handles the shoot button.
	/// </summary>
	private void HandleShootBtn(){
		if (canShoot && Input.GetKeyDown (KeyCode.K)) {
			this.GetComponent<AudioSource>().Play();
			switch(playerController.playerState){
				case PlayerState.Idel:
					playerIdle.Shoot(transform.localScale.x);
					break;
				case PlayerState.Walk:
					playerWalk.Shoot(transform.localScale.x);
					break;
			}
		}
	}
}
