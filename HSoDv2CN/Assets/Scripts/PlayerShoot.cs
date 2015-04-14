using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	private PlayerMove playerMove;

	// Use this for initialization
	void Start () {
		playerMove = this.GetComponent<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		HandleShootBtn ();
	}

	private void ShootFinish(){
		playerMove.isShooting = false;
	}

	/// <summary>
	/// Handles the shoot button.
	/// </summary>
	private void HandleShootBtn(){
		if (Input.GetKeyDown (KeyCode.K)) {
			playerMove.isShooting = true;
			//TODO shoot bullet
			Invoke("ShootFinish",0.5f);
		}
	}
}
