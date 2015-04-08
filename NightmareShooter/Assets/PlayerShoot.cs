using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public float shootRate = 2f;
	private float timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1 / shootRate) {
			timer -= 1 / shootRate;
			Shoot();
		}
	}

	void Shoot(){

	}
}
