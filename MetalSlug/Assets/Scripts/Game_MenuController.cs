using UnityEngine;
using System.Collections;

public class Game_MenuController : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject operationPanel;
	public GameObject diffcultyPanel;
	public GameObject charactorSelectPanel;
	public Color operationPanelColor;

	/// <summary>
	/// Raises the menu play event.
	/// </summary>
	public void OnMenuPlay(){
		menuPanel.SetActive (false);
		operationPanel.SetActive (true);
	}

	/// <summary>
	/// Raises the operation play event.
	/// </summary>
	public void OnOperationPlay(){
		operationPanel.GetComponent<UISprite> ().color = operationPanelColor;
		diffcultyPanel.SetActive (true);
	}

	/// <summary>
	/// Select Diffcult.
	/// </summary>
	public void OnDiffcultyClick(){
		operationPanel.SetActive (false);
		diffcultyPanel.SetActive (false);
		charactorSelectPanel.SetActive (true);
	}

	/// <summary>
	/// Raises the charactor select event.
	/// </summary>
	public void OnCharactorSelect(){
		Application.LoadLevel (1);
	}
}
