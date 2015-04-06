using UnityEngine;
using System.Collections;

public class Floting : MonoBehaviour {

	private float redian = 0;
	public float perRedian = 0.02f;
	public float radius = 0.2f;

	private Vector3 oldPos;

	// Use this for initialization
	void Start () {
		oldPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		redian += perRedian;
		float dy = Mathf.Cos (redian) * radius;
		transform.position = oldPos + new Vector3 (0, dy, 0);
	}
}
