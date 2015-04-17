using UnityEngine;
using System.Collections;

public class BlackMask : MonoBehaviour {

	public static BlackMask _instance;
	void Awake(){
		_instance = this;
		this.gameObject.SetActive (false);
	}


}

