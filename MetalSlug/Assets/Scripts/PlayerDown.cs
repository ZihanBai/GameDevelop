using UnityEngine;
using System.Collections;

public class PlayerDown : MonoBehaviour {

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
	/// The idle down sprite.
	/// </summary>
	public Sprite idleDownSprite;
	
	/// <summary>
	/// The idle up sprite array.
	/// </summary>
	public Sprite[] idleUpSpriteArray;
	
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
	
	/// <summary>
	/// The walk up sprite array.
	/// </summary>
	public Sprite[] walkUpSpriteArray;
	
	/// <summary>
	/// The index of the walk up.
	/// </summary>
	private int walkUpIndex = 0;
	
	/// <summary>
	/// The length of the walk up.
	/// </summary>
	private int walkUpLength = 0;
	
	/// <summary>
	/// The walk up timer.
	/// </summary>
	private float walkUpTimer = 0;
	
	/// <summary>
	/// The walk down sprite array.
	/// </summary>
	public Sprite[] walkDownSpriteArray;
	
	/// <summary>
	/// The index of the walk down.
	/// </summary>
	private int walkDownIndex = 0;
	
	/// <summary>
	/// The length of the walk down.
	/// </summary>
	private int walkDownLength = 0;
	
	/// <summary>
	/// The walk down timer.
	/// </summary>
	private float walkDownTimer = 0;

	public void Shoot(float v_h,bool isTopKeyDown,bool isBottomKeyDown){
		
	}


	// Use this for initialization
	void Start () {
		//time interval per frame
		animTimeInterval = 1 / animSpeed;
		idleUpLength = idleUpSpriteArray.Length;
		walkUpLength = walkUpSpriteArray.Length;
		walkDownLength = walkDownSpriteArray.Length;
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
		case AnimStatus.Walk:
			walkUpTimer += Time.deltaTime;
			if(walkUpTimer > animTimeInterval){
				walkUpTimer -= animTimeInterval;
				walkUpIndex++;
				walkUpIndex %= walkUpLength;
				upRenderer.sprite = walkUpSpriteArray[walkUpIndex];
			}
			walkDownTimer += Time.deltaTime;
			if(walkDownTimer > animTimeInterval){
				walkDownTimer -= animTimeInterval;
				walkDownIndex++;
				walkDownIndex %= walkDownLength;
				downRenderer.sprite = walkDownSpriteArray[walkDownIndex];
			}
			break;
		}
	}
}
