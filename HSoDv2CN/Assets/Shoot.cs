using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	/// <summary>
	/// The shoot rate.
	/// </summary>
	public float shootRate = 5f;
	
	/// <summary>
	/// The attack.
	/// </summary>
	public float attack = 30f;
	
	/// <summary>
	/// The timer.
	/// </summary>
	private float timer = 0f;
	
	private LineRenderer gunLine;

	// Use this for initialization
	void Start () {
		gunLine = this.GetComponent<LineRenderer> () as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
//		timer += Time.deltaTime;
//		if (timer > 1 / shootRate) {		//1 / shootRate is time cycle
//			timer -= 1 / shootRate;
//			GunShoot();
//		}
	}

	public void GunShoot(){
//		print ("GunShoot");
		gunLine.enabled = true;
		gunLine.SetPosition (0,transform.position + new Vector3(0,0,-1));
		Ray ray = new Ray (transform.position, transform.position + new Vector3(100,0,0));
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			gunLine.SetPosition (1, hitInfo.point+new Vector3(0,0,-1));
			//if shoot enemy
			if(hitInfo.collider.tag == "Enemy"){
				print("Shoot Enemy");
				//hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);
			}
		} else {
			gunLine.SetPosition(1,transform.position + (transform.forward + new Vector3(0,0,-1))*100);
		}
		Invoke("ClearEffect",0.05f);
	}

	/// <summary>
	/// Clears the effect.
	/// </summary>
	void ClearEffect(){
		gunLine.enabled = false;
	}
}
