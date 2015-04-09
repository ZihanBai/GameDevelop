using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	/// <summary>
	/// The speed.
	/// </summary>
	public float speed = 1f;

	/// <summary>
	/// The animator.
	/// </summary>
	private Animator animator;

	/// <summary>
	/// The index of the ground layer.
	/// </summary>
	private int groundLayerIndex = -1;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Control Moveing
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
//		transform.Translate (new Vector3 (h, 0, v) * speed * Time.deltaTime);
		GetComponent<Rigidbody>().MovePosition (transform.position + new Vector3 (h, 0, v) * speed * Time.deltaTime);

		//Control Rotation
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo, 200f, groundLayerIndex)) {
			Vector3 target = hitInfo.point;
			target.y = transform.position.y;
			transform.LookAt(target);
		}

		//Control Animation
		bool isWalking = h != 0f || v != 0f;
		animator.SetBool ("Move", isWalking);
	}
}
