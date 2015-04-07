using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI () {
		if (GameController.showScore) {
			GUIStyle style = new GUIStyle ();
			style.normal.textColor = Color.black;
			style.fontSize = 16;
			style.fontStyle = FontStyle.Bold;
			GUI.Label (new Rect (40, 17, 70, 35), "Score:" + GameController.score, style);
		}
	}
}
