using UnityEngine;
using System.Collections;

public class CardGenerator : MonoBehaviour {

	public GameObject cardPrefab;

	public Transform fromCard;

	public Transform toCard;

	public string[] cardNams;

	public float transformTime = 2f;

	public int transformSpeed = 20;

	private bool isTransforming = false;

	private float timer;

	private UISprite nowGenerateCard;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			RandomGenerateCard();
		}
		if (isTransforming) {
			timer += Time.deltaTime;
			int index = (int)(timer / (1f/transformSpeed));
			index %= cardNams.Length;
			nowGenerateCard.spriteName = cardNams[index];
			if(timer > transformTime){
				//transform finishied
				isTransforming = false;
				timer = 0;
			}
		}
	}

	public void RandomGenerateCard(){
		GameObject go = NGUITools.AddChild (this.gameObject, cardPrefab);
		go.transform.position = fromCard.position;
		nowGenerateCard = go.GetComponent<UISprite> ();
		iTween.MoveTo (go, toCard.position, 1f);
		isTransforming = true;

	}
}
