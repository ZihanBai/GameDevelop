using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject startUI;
	public GameObject gameUI;

	//goto GameUI
	public void EnterGameUI(){
		startUI.SetActive (false);
		gameUI.SetActive (true);
	}

	//return StartUI
	public void ReturnStartUI(){
		startUI.SetActive (true);
		gameUI.SetActive (false);
	}
}
