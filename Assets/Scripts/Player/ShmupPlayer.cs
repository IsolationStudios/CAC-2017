using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Bullet hell player
 */

namespace Player{
	public class ShmupPlayer : Player2D {
		public int hp;

		public GameObject bullet;
		int coolDown;

		override protected void FixedUpdate(){
			if (GameState.state == GameState.State.PUZZLE) {
				base.FixedUpdate ();

				if (Input.GetMouseButton (0) && coolDown <= 0) {
					Fire ();
					coolDown = 5;
				}

				coolDown--;
				if (coolDown < 0) {
					coolDown = 0;
				}
			}
		}

		void Fire(){
			Instantiate (bullet, transform.position + (Vector3.up*0.2f), transform.rotation);	
		}
	}
}