using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Player control for normal maze
 */

namespace Player {
	public class NormMazeControl : MonoBehaviour {

		float mult = 0.01f;
		Rigidbody2D rb;

		void Start(){
			rb = transform.GetComponent<Rigidbody2D> ();	
		}

		void Update(){
			// Controls
			if (InputManager.instance.GO_FORWARD_CONT) {
				rb.AddForce (Vector2.up);
			}
			if (InputManager.instance.TURN_RIGHT_CONT) {
				rb.AddForce (Vector2.right);
			}
			if (InputManager.instance.GO_BACKWARD_CONT) {
				rb.AddForce (Vector2.down);
			}
			if (InputManager.instance.TURN_LEFT_CONT) {
				rb.AddForce (Vector2.left);
			}

			// Win
			// TEMP: GO BACK TO ROOM 1
			if (transform.position.y < -0.5) {
				GameState.state = GameState.State.OPEN;
				GameManager.instance.GoTo ("room01");
			}
		}
	}
}