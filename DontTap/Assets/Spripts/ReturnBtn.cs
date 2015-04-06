using UnityEngine;
using System.Collections;

public class ReturnBtn : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
		//		print ("ReturnBtn gameController: " + gameController);
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		//		print("ReturnBtn onMouseDown");
		gameController.ReturnStartUI ();
	}
}
