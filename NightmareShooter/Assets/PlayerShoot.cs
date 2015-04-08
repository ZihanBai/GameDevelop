﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	/// <summary>
	/// The shoot rate.
	/// </summary>
	public float shootRate = 2f;

	/// <summary>
	/// The timer.
	/// </summary>
	private float timer = 0f;

	/// <summary>
	/// The particle system.
	/// </summary>
	private ParticleSystem particleSystem;

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		particleSystem = this.GetComponentInChildren<ParticleSystem> ();
		lineRenderer = this.GetComponent<LineRenderer> () as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1 / shootRate) {		//1 / shootRate is time cycle
			timer -= 1 / shootRate;
			Shoot();
		}
	}

	void Shoot(){
		GetComponent<Light>().enabled = true;
		particleSystem.Play ();
		lineRenderer.enabled = true;
		lineRenderer.SetPosition (0, transform.position);
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			lineRenderer.SetPosition (1, hitInfo.point);
		} else {
			lineRenderer.SetPosition(1,transform.position + transform.forward*100);
		}
		this.GetComponent<AudioSource> ().Play ();
		Invoke("ClearEffect",0.05f);
	}

	void ClearEffect(){
		GetComponent<Light>().enabled = false;
		lineRenderer.enabled = false;
	}
}