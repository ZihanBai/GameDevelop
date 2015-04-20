using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	
	public int maxHp = 30;
	
	public int minHp = 0;
	
	protected UILabel hpLabel;
	
	protected UISprite sprite;
	
	private int hpCount = 30;
	
	void Awake(){
		sprite = this.GetComponent<UISprite> ();
		hpLabel = this.transform.Find("hp").GetComponent<UILabel> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			TakeDamage(Random.Range(1,5));
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			PlusHP(Random.Range(1,5));
		}
	}
	
	public void TakeDamage(int damage){
		hpCount -= damage;
		hpLabel.text = hpCount.ToString ();
		if (hpCount <= minHp) {
			//TODO game stop
		}
	}
	
	public void PlusHP(int hp){
		hpCount += hp;
		if (hpCount >= maxHp)
			hpCount = maxHp;
		hpLabel.text = hpCount.ToString ();
	}
	
}
