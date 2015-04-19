using UnityEngine;
using System.Collections;

public class Hero1Crystal : MonoBehaviour {

	public int useableNum = 1;

	public int totalNum = 1;

	public int maxNum;
	
	public UISprite[] crystals;

	private UILabel label;

	void Awake(){
		maxNum = crystals.Length;
		label = this.GetComponent<UILabel> ();
	}

	public void UpdateShow(){
		label.text = string.Format ("{0}/{1}", useableNum, totalNum);
		for (int i = totalNum; i < maxNum; ++i) {
			crystals[i].gameObject.SetActive(false);
		}
		for (int i = 0; i < totalNum; ++i) {
			crystals[i].gameObject.SetActive(true);
		}
		for (int i = useableNum; i < totalNum; ++i) {
			crystals[i].spriteName = "TextInlineImages_normal";
		}
		for (int i = 0; i < useableNum; ++i) {
			crystals[i].spriteName = string.Format("TextInlineImages_{0:D2}",(i+1));
		}
	}
}
