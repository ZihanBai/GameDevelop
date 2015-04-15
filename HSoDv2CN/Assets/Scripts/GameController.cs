using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/// <summary>
	/// Raises the screen tap event.
	/// </summary>
	public void OnScreenTap(){
		Application.LoadLevel (1);
	}
}
