using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private UISprite sprite;

	private UILabel harmLabel;

	private UILabel hpLabel;

	void Awake(){
		sprite = this.GetComponent<UISprite>();
		harmLabel = transform.Find ("harmLabel").GetComponent<UILabel> ();
		hpLabel = transform.Find("hpLabel").GetComponent<UILabel> ();
	}

	private string CardName{
		get{
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

	public void SetDepth(int depth){
		sprite.depth = depth;
		harmLabel.depth = depth + 1;
		hpLabel.depth = depth + 1;
	}

}
