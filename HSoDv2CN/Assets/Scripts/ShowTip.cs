using UnityEngine;
using System.Collections;

public class ShowTip : MonoBehaviour {

	private float timer = 0f;
	
	private float showRate = 1f;
	
	private float showInterval = 0f;
	
	private bool isShowing = false;

	public GameObject Tip;

	// Use this for initialization
	void Start () {
		showInterval = 1 / showRate;
	}
	
	// Update is called once per frame
	void Update () {
//		Tip.gameObject.SetActive (true);
		timer += Time.deltaTime;
		if (timer > showInterval) {
			Tip.gameObject.SetActive (isShowing);
			isShowing = !isShowing;
			timer -= showInterval;
		}
	}
}
