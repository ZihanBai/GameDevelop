using UnityEngine;
using System.Collections;

public class ShowTip : MonoBehaviour {

	public float radius = 0.4f;

	public GameObject Tip;

	private float redian = 0f;

	// Update is called once per frame
	void Update () {
		redian += 0.04f;
		float alpha = (1f + Mathf.Cos (redian)) * radius;
		print (alpha);
		Tip.GetComponent<UISprite> ().color = new Color(255,255,255,alpha);
	}
}
