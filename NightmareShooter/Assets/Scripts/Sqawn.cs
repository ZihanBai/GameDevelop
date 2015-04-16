using UnityEngine;
using System.Collections;

public class Sqawn : MonoBehaviour {

	/// <summary>
	/// The enemy prefab.
	/// </summary>
	public GameObject enemyPrefab;

	/// <summary>
	/// The spawn time.
	/// </summary>
	public float spawnTime = 3;

	/// <summary>
	/// The timer.
	/// </summary>
	private float timer = 0;

	void Start(){
		InvokeRepeating ("ACC", 0, 1);
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			timer -= spawnTime;
			SpawnEnemy();
		}
	}

	private void ACC(){
		spawnTime -= 0.05f;
	}

	/// <summary>
	/// Spawns the enemy.
	/// </summary>
	private void SpawnEnemy(){
		GameObject.Instantiate (enemyPrefab, transform.position, transform.rotation);
	}

}
