using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	/// <summary>
	/// The block cant tap.
	/// </summary>
	public bool cantTap = false;
	/// <summary>
	/// The x off.
	/// </summary>
	private float xOff = -2.1f;
	/// <summary>
	/// The y off.
	/// </summary>
	private float yOff = -3.6f;
	/// <summary>
	/// The game controller.
	/// </summary>
	private GameController gameController;
	/// <summary>
	/// The index of the col.
	/// </summary>
	public int colIndex;
	/// <summary>
	/// The index of the row.
	/// </summary>
	public int rowIndex;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
		//		print ("Block gameController: " + gameController);
	}
	
	// Update is called once per frame
	void OnMouseDown () {
//		print ("Block onMouseDown");
//		int colIndex;
//		colIndex = Random.Range (0, 4);
//		SetPosition (colIndex,0);
		gameController.Select (this);
	}

	/// <summary>
	/// Sets the block's position.
	/// </summary>
	/// <param name="colIndex">Col index.</param>
	/// <param name="rowIndex">Row index.</param>
	public void SetPosition(int colIndex,int rowIndex){
		this.colIndex = colIndex;
		this.rowIndex = rowIndex;
		gameObject.transform.position = new Vector3 (xOff + colIndex * 1.5f, yOff + rowIndex * 2.8f);
		
	}

	/// <summary>
	/// Moves down.
	/// </summary>
	public void MoveDown(){
		SetPosition (this.colIndex, this.rowIndex - 1);
	}
}
