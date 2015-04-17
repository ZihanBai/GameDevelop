using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public MovieTexture movTexture;

	public bool isDrawMov = true;

	public bool isShowMessage = false;

	// Use this for initialization
	void Start () {
		movTexture.loop = false;
		movTexture.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDrawMov) {
			if(Input.GetMouseButtonDown(0) && !isShowMessage){
				isShowMessage = true;
			}else if(Input.GetMouseButtonDown(0) && isShowMessage){
				StopMovie();
			}
		}
		if (isDrawMov != movTexture.isPlaying) {
			StopMovie();
		}

	}

	void OnGUI(){
		if (isDrawMov) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), movTexture);
			if(isShowMessage){
				GUI.Label(new Rect(Screen.width/2 - 100,Screen.height/2,200,40),"Click again to stop play mov");
			}
		}
	}

	private void StopMovie(){
		movTexture.Stop ();
		isDrawMov = false;
	}

}
