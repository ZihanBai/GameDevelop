using UnityEngine;
using System.Collections;

public class DesCard : MonoBehaviour {

	public static DesCard _instance;

	private UISprite sprite;

	void Awake(){
		_instance = this;
		sprite = this.GetComponent<UISprite> ();
		this.gameObject.SetActive (false);
	}

	public void ShowCard(string cardName){
		this.gameObject.SetActive (true);
		sprite.spriteName = cardName;
		iTween.FadeTo (this.gameObject, 0, 3f);
	}
}
