using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Player control for normal maze
 */

namespace Player {
	public class NormMazeControl : Player2D {
		override protected void Update(){
			base.Update ();

			// Win
			// TEMP: GO BACK TO ROOM 1
			if (transform.position.y < -0.5) {
				GameState.state = GameState.State.OPEN;
				GameManager.instance.GoTo ("room01");
			}
		}
	}
}