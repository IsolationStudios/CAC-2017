using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Player control in 2D space
 */

namespace Player {
	public class Player2D : MonoBehaviour {

		Rigidbody2D rb;

		void Start(){
			rb = transform.GetComponent<Rigidbody2D> ();
			rb.mass = 5;
		}

		protected virtual void Update(){
			// Controls
			if (InputManager.instance.GO_FORWARD_CONT) {
				rb.AddForce (Vector2.up * 10*rb.mass);
			}
			if (InputManager.instance.TURN_RIGHT_CONT) {
				rb.AddForce (Vector2.right * 10*rb.mass);
			}
			if (InputManager.instance.GO_BACKWARD_CONT) {
				rb.AddForce (Vector2.down * 10*rb.mass);
			}
			if (InputManager.instance.TURN_LEFT_CONT) {
				rb.AddForce (Vector2.left * 10*rb.mass);
			}
		}
	}
}