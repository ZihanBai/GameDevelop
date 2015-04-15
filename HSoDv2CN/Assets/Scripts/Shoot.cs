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

	public void GunShoot(float direction){
		gunLine.enabled = true;
		Vector3 startPositon = transform.position + new Vector3 (0, 0, -1);
		Vector3 targetPosition = transform.position;
		if(direction >= 0.8)
			targetPosition += new Vector3 (100, 0, -1);
		else
			targetPosition += new Vector3 (-100, 0, -1);
		print ("startPositon:" + startPositon);
		print ("targetPosition" + targetPosition);
		gunLine.SetPosition (0,startPositon);

		Ray ray = new Ray (startPositon, targetPosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			gunLine.SetPosition (1, hitInfo.point);
			print("hitInfo.point:" + hitInfo.point);
			//if shoot enemy
			if(hitInfo.collider.tag == "Enemy"){
				hitInfo.collider.GetComponent<EnemyController>().TakeDamage(attack);
			}
		} else {
			gunLine.SetPosition(1,targetPosition);
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
