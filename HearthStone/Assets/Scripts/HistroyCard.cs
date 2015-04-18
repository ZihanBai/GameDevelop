using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HistroyCard : MonoBehaviour {

	public Transform inCard;
	public Transform outCard;
	public Transform card1;
	public Transform card2;
	public GameObject cardPrefab;

	private float yOffset;
	private List<GameObject> cardList = new List<GameObject>();

	void Start(){
		yOffset = card1.position.y - card2.position.y;
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			StartCoroutine( AddCard() );
		}
	}

	public IEnumerator AddCard(){
		GameObject go =	GameObject.Instantiate (cardPrefab, inCard.position, Quaternion.identity) as GameObject;
		yield return 1;
		go.transform.position = inCard.position;
		iTween.MoveTo (go, card1.position, 1f);
		cardList.Add (go);
		if (cardList.Count == 9) {
			iTween.MoveTo(cardList[0],outCard.position,0.5f);
			Destroy(cardList[0],2f);
			cardList.RemoveAt(0);
		}
		for (int i = 0; i < cardList.Count - 1; ++i) {
			iTween.MoveTo(cardList[i],cardList[i].transform.position - new Vector3(0,yOffset,0),0.5f);
		}
	}
}
