using UnityEngine;
using System.Collections;

public class LeftHandController : MonoBehaviour {

	public float speed = 1000f;

	private bool armUp = false;

	private bool rotating = false;

	public float angle = 0;

	void Update(){
		if (rotating && angle < 70) {
			angle += speed * Time.deltaTime;
			if(armUp)
				transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			else
				transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			if(angle > 70){
				rotating = false;
				armUp = !armUp;
				angle = 0;
			}
		}
	}

	public void DownForIdle(){
		if (armUp) {
			rotating = true;
		}
	}

	public void UpForShoot(){
		if (!armUp) {
			rotating = true;
		}
	}

}
