using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Controls player movement on main world
 */

namespace Player {
	public class PlayerMoveControl : MonoBehaviour {
		int counter;

		int speed = 10;
		float threshold = 0.1f;
		Vector3 target;

		void Update () {
			if (GameState.state == GameState.State.OPEN) {
				// Moving
				if (InputManager.instance.GO_FORWARD_CONT) {
					target = transform.position + (transform.forward*10);

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (InputManager.instance.GO_BACKWARD_CONT) {
					target = transform.position - (transform.forward*10);

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (InputManager.instance.GO_LEFT_CONT) {
					target = transform.position - (transform.right*10);

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (InputManager.instance.GO_RIGHT_CONT) {
					target = transform.position + (transform.right*10);

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}

				// Turning
				else if (InputManager.instance.TURN_RIGHT) {
					GameState.state = GameState.State.MOVING;
					InvokeRepeating ("TurnRight", 0, 0.01f);
				}
				else if (InputManager.instance.TURN_LEFT) {
					GameState.state = GameState.State.MOVING;
					InvokeRepeating ("TurnLeft", 0, 0.01f);
				}
			}
		}

		void TurnLeft(){
			transform.Rotate (new Vector3 (0, -90 / 10, 0));
			counter++;
			if (counter >= 10) {
				CancelInvoke ();
				counter = 0;
				GameState.state = GameState.State.OPEN;
			}
		}
		void TurnRight(){
			transform.Rotate (new Vector3 (0, 90 / 10, 0));
			counter++;
			if (counter >= 10) {
				CancelInvoke ();
				counter = 0;
				GameState.state = GameState.State.OPEN;
			}
		}

		void MoveToFloor(){
			Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
				target,
				Time.deltaTime * speed);

			// Stops lerp
			if (ExtraMath.CheckCloseEnough (Camera.main.transform.position, target, threshold)) {
				CancelInvoke ();

				GameState.state = GameState.State.OPEN;
				GameState.lookingAt = -1;
			}
		}
	}
}
