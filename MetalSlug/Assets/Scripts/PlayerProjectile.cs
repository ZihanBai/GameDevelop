using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
