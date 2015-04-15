using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;
	
	private float walkTimer = 0f;
	
	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;
	
	/// <summary>
	/// Up renderer.
	/// </summary>
	public SpriteRenderer walkRenderer;
	
	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] walkSpriteArray;
	
	/// <summary>
	/// The index of the idle up.
	/// </summary>
	private int walkIndex = 0;
	
	/// <summary>
	/// The length of the idle up.
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
