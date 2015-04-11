using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public Vector3 targetPos;

	public Vector3 endPos;

	public Wheel[] wheels; 

	public Damper damper;

	public int smoothing = 3;

	/// <summary>
	/// The is reaching.
	/// </summary>
	private bool isReaching = false;

	// Use this for initialization
	void Start () {
		Invoke ("PlaySound", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isReaching) {
			transform.position = Vector3.Lerp (transform.position, targetPos, smoothing * Time.deltaTime);
			if (Vector3.Distance (transform.position, targetPos) < 0.3f) {
				this.isReaching = true;
				OnReach (); 
			}
		}
	}

	private void OnReach(){
		foreach(Wheel w in wheels){
			w.Stop(); 
		}
		//rotate damper
		damper.StartRotate();
		//player get down

		//car go out
		Invoke ("GoOut", 2f);
	}

	/// <summary>
	/// Car Goes out.
	/// </summary>
	private void GoOut(){
		targetPos = endPos;
		isReaching = false;
		foreach(Wheel w in wheels){
			w.Start(); 
		}
//		Destroy (this.gameObject,1f);
	}

	private void PlaySound(){
		this.GetComponent<AudioSource> ().Play ();
	}
}
