using UnityEngine;
using System.Collections;

public class Damper : MonoBehaviour {

	public float speed = 120f;

	private bool isRotate = false;

	private float angle = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotate && angle < 130) {
			angle += speed * Time.deltaTime;
			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			if(angle > 130f){
				isRotate = false;
			}
		}
	}

	public void StartRotate(){
		isRotate = true;
	}
}
