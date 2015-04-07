using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	/// <summary>
	/// The score.
	/// </summary>
	public static int score = 0;
	/// <summary>
	/// if true then show score.
	/// </summary>
	public static bool showScore = false;
	public GameObject startUI;
	public GameObject gameUI;
	public GameObject container;
	public GameObject whiteBlock;
	public GameObject normalBlock;
	private ArrayList blocks;

	//goto GameUI
	public void EnterGameUI(){
		startUI.SetActive (false);
		gameUI.SetActive (true);
		StartGame ();
		//show Score
		showScore = true;
	}

	//return StartUI
	public void ReturnStartUI(){
		startUI.SetActive (true);
		gameUI.SetActive (false);
		//Dont show ShowScore
		showScore = false;
		//Clean old blocks
		Clean ();
	}

	//start Game
	private void StartGame(){
		blocks = new ArrayList ();
		for (int rowIndex = 0; rowIndex < 4; rowIndex++) {
			AddBlock(rowIndex);
		}
	}

	/// <summary>
	/// Adds the block in rowIndex
	/// </summary>
	/// <param name="rowIndex">Row index.</param>
	void AddBlock(int rowIndex){
		//whiteBlock.GetComponent<Block> ().cantTap = true;
		float rnd = Random.Range (0f, 1f);
		GameObject prefab = rnd > 0.8f ? whiteBlock : normalBlock;
		GameObject o = Instantiate(prefab) as GameObject;
		o.transform.parent = container.transform;
		Block b = o.GetComponent<Block>();
		int colIndex = Random.Range (0, 4);
		b.SetPosition(colIndex,rowIndex);
		//add block to arraylist
		blocks.Add (b);
	}

	/// <summary>
	/// Select the specified block.
	/// </summary>
	/// <param name="block">Block.</param>
	public void Select(Block block){
		GetComponent<AudioSource>().Play ();
		score += block.cantTap ? -5 : 1;
		for (int i = 0; i < blocks.Count; i++) {
			Block b = (Block)blocks[i];
			b.MoveDown();
			if(b.rowIndex == -1){
				blocks.Remove(b);
				Destroy(b.gameObject);
				--i;
			}
		}
		AddBlock (3);
	}

	public void Clean(){
		for (int i = 0; i < blocks.Count; i++) {
			Block b = (Block)blocks[i];
			b.MoveDown();
			blocks.Remove(b);
			Destroy(b.gameObject);
			--i;
		}
		score = 0;
	}

}
