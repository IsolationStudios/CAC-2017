using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls player movement on main world
 */

namespace Player {
	public class MazeControl : MonoBehaviour {
		int counter;
		int coolDown = 0;

		void Update () {

			coolDown--;
			if (coolDown < 0)
				coolDown = 0;
			if (coolDown > 0)
				return;

			if (GameState.state == GameState.State.OPEN) {
				if (Input.GetKeyDown ("d")) {
					coolDown = 50;
					InvokeRepeating ("TurnRight", 0, 0.01f);
				}
				else if (Input.GetKeyDown ("a")) {
					coolDown = 50;
					InvokeRepeating ("TurnLeft", 0, 0.01f);
				}
			}
		}

		void TurnLeft(){
			transform.Rotate (new Vector3 (0, 0, 90 / 10));
			counter++;
			if (counter >= 10) {
				CancelInvoke ();
				counter = 0;
			}
		}
		void TurnRight(){
			transform.Rotate (new Vector3 (0, 0, -90 / 10));
			counter++;
			if (counter >= 10) {
				CancelInvoke ();
				counter = 0;
			}
		}


	}
}
