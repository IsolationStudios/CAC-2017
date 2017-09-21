using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Player control for normal maze
 */

namespace Player {
	public class NormMazeControl : Player2D {
		override protected void FixedUpdate(){
			base.FixedUpdate ();

			// Win
			// TEMP: GO BACK TO ROOM 1
			if (transform.position.y <= -1.7) {
				GameState.state = GameState.State.OPEN;
				GameManager.instance.GoTo ("2Droom01");
			}
		}
	}
}