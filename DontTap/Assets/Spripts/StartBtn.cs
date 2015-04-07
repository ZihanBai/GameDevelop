using UnityEngine;
using System.Collections;

public class StartBtn : MonoBehaviour {
	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
//		print ("StartBtn gameController: " + gameController);
	}
	
	// Update is called once per frame
	void OnMouseDown () {
//		print("StartBtn onMouseDown");
		gameController.EnterGameUI ();
		GameController.showScore = true;
	}
}
