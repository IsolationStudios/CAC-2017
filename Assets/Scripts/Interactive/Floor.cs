using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Floor that can be moved to
 */

namespace Interactive{
	public class Floor : MonoBehaviour {

		static int speed = 5;
		static float threshold = 0.1f;

		void OnMouseDown(){

			if(GameState.state == GameState.State.OPEN){

				CancelInvoke ();
				InvokeRepeating("MoveToFloor", 0, 0.01f);

				GameState.state = GameState.State.MOVING;
			}
		}

		void MoveToFloor(){

			Vector3 target = new Vector3 (
				                 transform.position.x,
				                 Camera.main.transform.position.y,
				                 transform.position.z
			                 );

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