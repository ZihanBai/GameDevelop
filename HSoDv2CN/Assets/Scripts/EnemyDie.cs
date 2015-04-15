using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;
	
	private float dieTimer = 0f;
	
	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;
	
	/// <summary>
	/// Up renderer.
	/// </summary>
	public SpriteRenderer dieRenderer;
	
	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] dieSpriteArray;
	
	/// <summary>
	/// The index of the idle up.
	/// </summary>
	private int dieIndex = 0;
	
	/// <summary>
	/// The length of the idle up.
	/// </summary>
	private int dieLength = 0;
	
	// Use this for initialization
	void Start () {
		animTimeInterval = 1 / animSpeed;
		dieLength = dieSpriteArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
		dieTimer += Time.deltaTime;
		if(dieTimer > animTimeInterval){
			dieTimer -= animTimeInterval;
			dieIndex++;
			if(dieIndex >= dieLength){
//				Destroy(this.gameObject);
				return;
			}
			dieRenderer.sprite = dieSpriteArray[dieIndex];
		}
	}
}
