using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	private float xOff = -2.1f;
	private float yOff = -3.6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		print ("Block onMouseDown");
//		int colIndex;
//		colIndex = Random.Range (0, 4);
//		SetPosition (colIndex,0);
	}

	public void SetPosition(int colIndex,int rowIndex){
		gameObject.transform.position = new Vector3 (xOff + colIndex * 1.5f, yOff + rowIndex * 2.8f);
		
	}
}
