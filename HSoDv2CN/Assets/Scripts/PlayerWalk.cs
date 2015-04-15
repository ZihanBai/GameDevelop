using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {

	public Shoot shoot;

	public void Shoot(float direction){
		shoot.GunShoot (direction);
	}
}
