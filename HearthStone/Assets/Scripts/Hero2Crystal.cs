using UnityEngine;
using System.Collections;

public class Hero2Crystal : MonoBehaviour {

	public int useableNum = 1;
	
	public int totalNum = 1;

	private UILabel label;

	void Awake(){
		label = this.GetComponent<UILabel> ();
	}

	void Update(){
		UpdateShow ();
	}

	public void UpdateShow(){
		label.text = string.Format ("{0}/{1}", useableNum, totalNum);
	}

}
