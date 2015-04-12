using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	/// <summary>
	/// The Player status.
	/// </summary>
	public AnimStatus status = AnimStatus.Idel;
	
	/// <summary>
	/// The animation speed.
	/// </summary>
	public float animSpeed = 7f;
	
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
	/// The idle down sprite array.
	/// </summary>
	public Sprite[] idleDownSpriteArray;

	public Sprite shootUpSprite;
	public Sprite shootHorizontalSprite;

	/// <summary>
	/// The index of the idle down.
	/// </summary>
	private int idleDownIndex = 0;
	
	/// <summary>
	/// The length of the idle down.
	/// </summary>
	private int idleDownLength = 0;
	
	/// <summary>
	/// The idle down timer.
	/// </summary>
	private float idleDownTimer = 0;

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

	private bool shoot = false;

	private ShootDir shootDir;

	public GameObject projectilePrefab;
	public Transform shootUpPos;
	public Transform shootHorizontalPos;

	void LateUpdate(){
		if (shoot) {
			shoot = false;
		}
		//Shoot Bullet
		Vector3 pos = Vector3.zero;
		if (shootDir == ShootDir.Top) {
			pos = shootUpPos.position;
		} else if (shootDir == ShootDir.Left || shootDir == ShootDir.Right) {
			pos = shootHorizontalPos.position;
		}
		int z_rotation = 0;
		switch (shootDir) {
		case ShootDir.Left:
			z_rotation = 180;
			upRenderer.sprite = shootHorizontalSprite;
			break;
		case ShootDir.Right:
			z_rotation = 0;
			upRenderer.sprite = shootHorizontalSprite;
			break;
		case ShootDir.Top:
			z_rotation = 90;
			upRenderer.sprite = shootUpSprite;
			break;
		case ShootDir.Down:
			z_rotation = 270;
			break;
		default:
			break;
		}
		GameObject.Instantiate (projectilePrefab, pos, Quaternion.Euler (0, 0, z_rotation));
	}

	public void Shoot(bool isTopKeyDown,bool isBottomKeyDown){
		shoot = true;
		//Get Shoot Direction
		if (!isTopKeyDown && !isBottomKeyDown) {
			shootDir = transform.localScale.x == 1 ? ShootDir.Left : ShootDir.Right;
		} else if (isTopKeyDown) {
			shootDir = ShootDir.Top;
		} else {
			shootDir = ShootDir.Down;
		}
	}

	// Use this for initialization
	void Start () {
		//time interval per frame
		animTimeInterval = 1 / animSpeed;
		idleUpLength = idleUpSpriteArray.Length;
		idleDownLength = idleDownSpriteArray.Length;
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
			idleDownTimer += Time.deltaTime;
			if(idleDownTimer > animTimeInterval){
				idleDownTimer -= animTimeInterval;
				idleDownIndex++;
				idleDownIndex %= idleDownLength;
				downRenderer.sprite = idleDownSpriteArray[idleDownIndex];
			}
			break;
		}
	}
}
