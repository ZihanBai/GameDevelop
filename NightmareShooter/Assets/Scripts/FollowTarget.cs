using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
	private float smoothing = 3;
	/// <summary>
	/// The player.
	/// </summary>
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPosition = player.position + new Vector3 (0, 6, -6);
		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	}
}
