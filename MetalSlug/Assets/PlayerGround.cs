using UnityEngine;
using System.Collections;

public enum AnimStatus{
	Idel,
	Walk
}

public class PlayerGround : MonoBehaviour {

	/// <summary>
	/// The Player status.
	/// </summary>
	public AnimStatus status = AnimStatus.Idel;

	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 10f;

	/// <summary>
	/// The animation time interval.
	/// </summary>
	private float animTimeInterval = 0;

	/// <summary>
	/// Up renderer.
	/// </summary>
	public SpriteRenderer upRenderer;

	/// <summary>
	/// Down renderer.
	/// </summary>
	public SpriteRenderer downRenderer;

	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] idleUpSpriteArray;

	/// <summary>
	/// The idle down sprite.
	/// </summary>
	public Sprite idleDownSprite;

	/// <summary>
	/// The index of the idle up.
	/// </summary>
	private int idleUpIndex = 0;

	/// <summary>
	/// The length of the idle up.
	/// </summary>
	private int idleUpLength = 0;

	/// <summary>
	/// The idle up timer.
	/// </summary>
	private float idleUpTimer = 0;

	// Use this for initialization
	void Start () {
		//time interval per frame
		animTimeInterval = 1 / animSpeed;
		idleUpLength = idleUpSpriteArray.Length;
	}
	
	// Update is called once per frame
	void Update () {
		switch (status) {
		case AnimStatus.Idel:
			idleUpTimer += Time.deltaTime;
			if(idleUpTimer > animTimeInterval){
				idleUpTimer -= animTimeInterval;
				idleUpIndex++;
				idleUpIndex %= idleUpLength;
				upRenderer.sprite = idleUpSpriteArray[idleUpIndex];
			}
			downRenderer.sprite = idleDownSprite;
			break;
		}
	}
}
