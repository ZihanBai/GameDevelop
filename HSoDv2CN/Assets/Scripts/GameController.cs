using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/// <summary>
	/// Raises the screen tap event.
	/// </summary>
	public void OnScreenTap(){
		print("test");
		Application.LoadLevel (1);
	}
}
