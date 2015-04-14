using UnityEngine;
using System.Collections;

public class LeftHandController : MonoBehaviour {

	public float speed = 180f;

	private bool rotating = false;

	private bool upState = false;

	private float angle = 0;

	// Update is called once per frame
	void Update () {
		HandleRotateSelf ();
	}

	private void HandleRotateSelf(){
		if (upState) {
			rotating = true;
			RotateUp ();
		} else {
			rotating = true;
			RotateDown();
		}
	}

	private void RotateUp(){
		if (rotating && angle < 70) {
			angle += speed * Time.deltaTime;
			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			if(angle > 70)
				rotating = false;
		}
	}

	private void RotateDown(){
		if (rotating && angle < 70) {
			angle += speed * Time.deltaTime;
			transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			if(angle > 70)
				rotating = false;
		}
	}

	public void UpForShoot(){
		print("UpForShoot");
		upState = true;
	}

	public void DownForIdle(){
		print("DownForIdle");
		upState = false;
	}
}
