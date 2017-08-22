using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Controls gravity maze
 */

namespace Player {
	public class GravMazeControl : MonoBehaviour {
		int counter;
		int coolDown = 0;

		public GameObject target;

		void Update () {
			coolDown--;
			if (coolDown < 0)
				coolDown = 0;
			if (coolDown > 0)
				return;

			// Controls
			if (GameState.state == GameState.State.PUZZLE) {
				if (InputManager.instance.TURN_RIGHT) {
					coolDown = 30;
					InvokeRepeating ("TurnRight", 0, 0.01f);
				}
				else if (InputManager.instance.TURN_LEFT) {
					coolDown = 30;
					InvokeRepeating ("TurnLeft", 0, 0.01f);
				}
			}

			//Win
			//TEMP: GO BACK TO ROOM 1
			if (target.transform.position.y < -1) {
				GameState.state = GameState.State.OPEN;
				GameManager.instance.GoTo ("room01");
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
