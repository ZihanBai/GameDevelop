using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;

	/// <summary>
	/// The walk renderer.
	/// </summary>
	public SpriteRenderer walkRenderer;
	
	/// <summary>
	/// The walk sprite array.
	/// </summary>
	public Sprite[] walkSpriteArray;

	/// <summary>
	/// The walk timer.
	/// </summary>
	private float walkTimer = 0f;
	
	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;

	/// <summary>
	/// The index of the walk.
	/// </summary>
	private int walkIndex = 0;
	
	/// <summary>
	/// The length of the walk.
	/// </summary>
	private int walkLength = 0;
	
	// Use this for initialization
	void Start () {
		animTimeInterval = 1 / animSpeed;
		walkLength = walkSpriteArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
		walkTimer += Time.deltaTime;
		if(walkTimer > animTimeInterval){
			walkTimer -= animTimeInterval;
			walkIndex++;
			walkIndex %= walkLength;
			walkRenderer.sprite = walkSpriteArray[walkIndex];
		}
	}
}
