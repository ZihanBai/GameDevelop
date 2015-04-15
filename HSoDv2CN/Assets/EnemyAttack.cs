using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;
	
	private float attackTimer = 0f;
	
	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;
	
	/// <summary>
	/// Up renderer.
	/// </summary>
	public SpriteRenderer attackRenderer;
	
	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] attackSpriteArray;
	
	/// <summary>
	/// The index of the idle up.
	/// </summary>
	private int attackIndex = 0;
	
	/// <summary>
	/// The length of the idle up.
	/// </summary>
	private int attackLength = 0;
	
	// Use this for initialization
	void Start () {
		animTimeInterval = 1 / animSpeed;
		attackLength = attackSpriteArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer += Time.deltaTime;
		if(attackTimer > animTimeInterval){
			attackTimer -= animTimeInterval;
			attackIndex++;
			attackIndex %= attackLength;
			attackRenderer.sprite = attackSpriteArray[attackIndex];
		}
	}
}
