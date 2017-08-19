using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player{
	public class ShmupPlayer : Player2D {

		public GameObject bullet;
		int coolDown;

		override protected void Update(){
			base.Update ();

			if(Input.GetMouseButton(0) && coolDown <= 0){
				Fire ();
				coolDown = 100;
			}

			coolDown--;
			if(coolDown < 0){
				coolDown = 0;
			}
		}

		void Fire(){
			Instantiate (bullet, transform.position + Vector3.up*0.2f, transform.rotation);	
		}
	}
}