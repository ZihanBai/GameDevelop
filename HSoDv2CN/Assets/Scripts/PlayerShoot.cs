using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HandleShootBtn ();
	}

	private void ShootFinish(){
	}

	/// <summary>
	/// Handles the shoot button.
	/// </summary>
	private void HandleShootBtn(){
		if (Input.GetKeyDown (KeyCode.K)) {
		}
	}
}
