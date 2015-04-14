using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 5f;

	private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//handle Left (A) and Right (D) button
		HandleHorizontalBtn ();
		HandleVerticalBtn ();
	
	}

	/// <summary>
	/// Handles the horizontal button.
	/// </summary>
	private void HandleHorizontalBtn(){
		float h = Input.GetAxis ("Horizontal");
		Vector3 r = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (h * speed, r.y, r.z);
	}

	private void HandleVerticalBtn(){
		float v = Input.GetAxis ("Vertical");
		Vector3 r = myRigidBody.velocity;
		myRigidBody.velocity = new Vector3 (r.x, v * speed, r.z);
	}
}
