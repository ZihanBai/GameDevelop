using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	public float speed = 200;

	private bool isRotate = true;

	// Use this for initialization
	public void Start () {
		isRotate = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isRotate)
			transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
	}

	public void Stop(){
		isRotate = false;
	}
}
