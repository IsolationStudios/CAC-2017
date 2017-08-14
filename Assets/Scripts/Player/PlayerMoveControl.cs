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
				if (Input.GetKeyDown ("w")) {
					target = transform.position + transform.forward * 10;

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (Input.GetKeyDown ("s")) {
					target = transform.position - transform.forward * 10;

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (Input.GetKeyDown ("a") && Input.GetKey (KeyCode.LeftShift)) {
					target = transform.position - transform.right * 10;

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}
				else if (Input.GetKeyDown ("d") && Input.GetKey (KeyCode.LeftShift)) {
					target = transform.position + transform.right * 10;

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					InvokeRepeating("MoveToFloor", 0, 0.01f);

					GameState.state = GameState.State.MOVING;
				}

				// Turning
				else if (Input.GetKeyDown ("d")) {
					GameState.state = GameState.State.MOVING;
					InvokeRepeating ("TurnRight", 0, 0.01f);
				}
				else if (Input.GetKeyDown ("a")) {
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
