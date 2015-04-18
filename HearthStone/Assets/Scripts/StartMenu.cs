using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public MovieTexture movTexture;

	public bool isDrawMov = true;

	public bool isShowMessage = false;

	public TweenScale logoTweenScale;

	public TweenPosition selectRoleTweenScale;

	public UISprite hero1;

	private bool isCanShowSelectRole = false;//if true show select role page

	// Use this for initialization
	void Start () {
		movTexture.loop = false;
		movTexture.Play ();
		logoTweenScale.AddOnFinished (this.OnLogoFinished);
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
		if (isCanShowSelectRole && Input.GetMouseButtonDown (0)) {
			 //show role select page
			isCanShowSelectRole = false;
			selectRoleTweenScale.PlayForward();
		}
	}

	void OnGUI(){
		if (isDrawMov) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), movTexture);
			if(isShowMessage){
				GUI.Label(new Rect(Screen.width/2 - 70,Screen.height/2,200,40),"Click again to stop play mov");
			}
		}
	}

	private void StopMovie(){
		movTexture.Stop ();
		isDrawMov = false;
		logoTweenScale.PlayForward ();
	}

	private void OnLogoFinished(){
		this.isCanShowSelectRole = true;
	}

	public void OnPlayerButtonClick(){
		BlackMask._instance.Show ();
		VSShow._instance.Show (hero1.spriteName,string.Format("hero{0}",Random.Range(1,10)));
		StartCoroutine (LoadPlayScene());
	}

	IEnumerator LoadPlayScene(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (1);
	}

}
