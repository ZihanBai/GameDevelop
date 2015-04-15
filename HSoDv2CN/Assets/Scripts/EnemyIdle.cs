using UnityEngine;
using System.Collections;

public class EnemyIdle : MonoBehaviour {

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;

	private float idleTimer = 0f;

	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;
	
	/// <summary>
	/// Up renderer.
	/// </summary>
	public SpriteRenderer idleRenderer;

	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] idleSpriteArray;

	/// <summary>
	/// The index of the idle up.
	/// </summary>
	private int idleIndex = 0;
	
	/// <summary>
	/// The length of the idle up.
	/// </summary>
	private int idleLength = 0;

	// Use this for initialization
	void Start () {
		animTimeInterval = 1 / animSpeed;
		idleLength = idleSpriteArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
		idleTimer += Time.deltaTime;
		if(idleTimer > animTimeInterval){
			idleTimer -= animTimeInterval;
			idleIndex++;
			idleIndex %= idleLength;
			idleRenderer.sprite = idleSpriteArray[idleIndex];
		}
	}
}
