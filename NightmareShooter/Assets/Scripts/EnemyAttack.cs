using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float attack = 5f;
	private float attackTime = 1f;
	private float timer;
	private EnemyHealth enemyHealth;

	// Use this for initialization
	void Start(){
		timer = attack;
		enemyHealth = this.GetComponent<EnemyHealth> ();
	}

	public void OnTriggerStay(Collider col){
		//not hit player or already dead
		if (!(col.tag == Tags.player) || enemyHealth.hp <= 0)
			return;
		timer += Time.deltaTime;
		if (timer >= attackTime) {
			timer -= attackTime;
			col.GetComponent<PlayerHealth>().TakeDamage(attack);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
