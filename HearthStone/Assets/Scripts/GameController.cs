using UnityEngine;
using System.Collections;

public enum GameState{
	CardGenerating,		//genera card
	PlayCard,			//play mode
	End					//game end
}

public class GameController : MonoBehaviour {

	public GameState gameState = GameState.CardGenerating;
	public float cycleTime = 60f;
	public MyCard myCard;

	private UISprite wickpopeSprite;
	private float timer = 0f;
	private float wickpopeLength;
	private string currentHeroName = "hero1";
	private CardGenerator cardGenerator;

	void Awake(){
		wickpopeSprite = this.transform.Find ("wickpope").GetComponent<UISprite> ();
		wickpopeLength = wickpopeSprite.width;
		wickpopeSprite.width = 0;
		cardGenerator = this.GetComponent<CardGenerator> ();
		StartCoroutine( GenerateCardForHero1 ());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState == GameState.PlayCard) {
			timer += Time.deltaTime;
			if(timer > cycleTime){
				//end this section
				TransformPlayer();
			}else if((cycleTime - timer) <= 15){
				wickpopeSprite.width = (int)(((cycleTime - timer) / 15f)*wickpopeLength);
			}
		}
	}

	private IEnumerator GenerateCardForHero1(){
		//first generate 4 cards
		int count = 4;
		GameObject cardGo = null;
		while (count > 0) {
			cardGo = cardGenerator.RandomGenerateCard ();
			yield return new WaitForSeconds (2f);
			//return card
			myCard.AddCard (cardGo);
			count--;
		}
	}

	private void TransformPlayer(){

	}

}
