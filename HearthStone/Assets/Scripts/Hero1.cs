using UnityEngine;
using System.Collections;

public class Hero1 : Hero {

	// Use this for initialization
	void Start () {
		string heroName = PlayerPrefs.GetString ("hero1");
		sprite.spriteName = heroName;
	}

}
