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
		Vector3 oldPos;

		void Start(){

			//Init pos from save
			if (!GameManager.instance.isInit) {
				transform.position = new Vector3 (
					GameManager.instance.initX,
					transform.position.y,
					GameManager.instance.initZ
				);
				transform.rotation = Quaternion.Euler(
					0,
					GameManager.instance.initY,
					0
				);

				GameManager.instance.isInit = true;
			}

			//Set correct position - HARDCODED
			//TODO: add correct positions
			if (GameManager.instance.previousScene == "room02" && GameManager.instance.currentScene == "room03") {
				transform.position = new Vector3 (10, -0.5f, 0);
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			else if (GameManager.instance.previousScene == "room03" && GameManager.instance.currentScene == "room02") {
				transform.position = new Vector3 (-170, -0.5f, -20);
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			else if (GameManager.instance.previousScene == "room03" && GameManager.instance.currentScene == "room04") {
				transform.position = new Vector3 (0, -0.5f, 20);
				transform.rotation = Quaternion.Euler (0, 90, 0);
			}
			else if (GameManager.instance.previousScene == "room04" && GameManager.instance.currentScene == "room03") {
				transform.position = new Vector3 (110, -0.5f, 160);
				transform.rotation = Quaternion.Euler (0, 180, 0);
			}
			else if (GameManager.instance.previousScene == "room04" && GameManager.instance.currentScene == "room05") {
				transform.position = new Vector3 (30, -0.5f, 140);
				transform.rotation = Quaternion.Euler (0, 90, 0);
			}
			else if (GameManager.instance.previousScene == "room05" && GameManager.instance.currentScene == "room04") {
				transform.position = new Vector3 (100, -0.5f, 60);
				transform.rotation = Quaternion.Euler (0, -90, 0);
			}
			else if (GameManager.instance.previousScene == "room05" && GameManager.instance.currentScene == "room06") {
				transform.position = new Vector3 (40, -0.5f, 280);
				transform.rotation = Quaternion.Euler (0, 180, 0);
			}
			else if (GameManager.instance.previousScene == "room06" && GameManager.instance.currentScene == "room05") {
				transform.position = new Vector3 (50, -0.5f, 10);
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}

		void Update () {
			if (GameState.state == GameState.State.OPEN) {
				// Moving
				if (InputManager.instance.GO_FORWARD_CONT) {
					target = transform.position + (transform.forward*10);

					if (!GameManager.instance.CheckInVec(target))
						return;

					CancelInvoke ();
					oldPos = transform.position;
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
			Camera.main.transform.position = Vector3.Lerp (
				Camera.main.transform.position,
				target,
				Time.deltaTime * speed
			);

			// Stops lerp
			if (ExtraMath.CheckCloseEnough (Camera.main.transform.position, target, threshold)) {
				CancelInvoke ();

				//Round position
				//Adding 0.1 cause weird math...
				transform.position = new Vector3(
					ExtraMath.RoundToNearest(transform.position.x, 10) + 0.01f,
					transform.position.y,
					ExtraMath.RoundToNearest(transform.position.z, 10) + 0.01f
				);

				GameState.state = GameState.State.OPEN;
				GameState.lookingAt = -1;
			}
		}
	}
}
