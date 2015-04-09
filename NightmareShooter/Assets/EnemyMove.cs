using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform player;

	void Awake(){
		agent = this.GetComponent<NavMeshAgent> ();
	}


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination(player.position);

	}
}
