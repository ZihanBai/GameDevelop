using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject startUI;
	public GameObject gameUI;
	public GameObject container;
	public GameObject whiteBlock;
	public GameObject normalBlock;
	//goto GameUI
	public void EnterGameUI(){
		startUI.SetActive (false);
		gameUI.SetActive (true);
		StartGame ();
	}

	//return StartUI
	public void ReturnStartUI(){
		startUI.SetActive (true);
		gameUI.SetActive (false);
	}

	private void StartGame(){
		for (int rowIndex = 0; rowIndex < 4; rowIndex++) {
			GameObject o = Instantiate(whiteBlock) as GameObject;
			o.transform.parent = container.transform;
			Block b = o.GetComponent<Block>();
			int colIndex = Random.Range (0, 4);
			b.SetPosition(colIndex,rowIndex);
		}
	}
}
