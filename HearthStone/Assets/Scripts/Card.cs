using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private UISprite sprite;

	private string CardName{
		get{
			if(sprite == null){
				sprite = this.GetComponent<UISprite>();
			}
			return sprite.spriteName;
		}
	}

	void OnPress (bool isPressed)
	{
		print("test");
		if (isPressed) {
			DesCard._instance.ShowCard(CardName);
		}
	}

}
