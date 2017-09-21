using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages user input
 */

namespace Managers {
	public class InputManager : MonoBehaviour {
		public static InputManager instance;

		public bool GO_FORWARD;
		public bool GO_BACKWARD;
		public bool GO_RIGHT;
		public bool GO_LEFT;

		public bool TURN_RIGHT;
		public bool TURN_LEFT;

		public bool GO_FORWARD_CONT;
		public bool GO_BACKWARD_CONT;
		public bool GO_RIGHT_CONT;
		public bool GO_LEFT_CONT;
		public bool TURN_LEFT_CONT;
		public bool TURN_RIGHT_CONT;

		public bool PAUSE;

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		void Update(){
			DetectPC ();
		}

		void DetectPC(){
			if (Input.GetKeyDown ("a") && Input.GetKey (KeyCode.LeftShift)) {
				GO_LEFT = true;
			}
			else {
				GO_LEFT = false;
			}
			if (Input.GetKeyDown ("d") && Input.GetKey (KeyCode.LeftShift)) {
				GO_RIGHT = true;
			}
			else {
				GO_RIGHT = false;
			}
			if (Input.GetKeyDown ("w")) {
				GO_FORWARD = true;
			}
			else {
				GO_FORWARD = false;
			}
			if (Input.GetKeyDown ("a")) {
				TURN_LEFT = true;
			}
			else {
				TURN_LEFT = false;
			}
			if (Input.GetKeyDown ("s")) {
				GO_BACKWARD = true;
			}
			else {
				GO_BACKWARD = false;
			}
			if (Input.GetKeyDown ("d")) {
				TURN_RIGHT = true;
			}
			else {
				TURN_RIGHT = false;
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				PAUSE = true;
			}
			else {
				PAUSE = false;
			}

			if (Input.GetKey ("a") && Input.GetKey (KeyCode.LeftShift)) {
				GO_LEFT_CONT = true;
			}
			else {
				GO_LEFT_CONT = false;
			}
			if (Input.GetKey ("d") && Input.GetKey (KeyCode.LeftShift)) {
				GO_RIGHT_CONT = true;
			}
			else {
				GO_RIGHT_CONT = false;
			}
			if (Input.GetKey ("w")) {
				GO_FORWARD_CONT = true;
			}
			else {
				GO_FORWARD_CONT = false;
			}
			if (Input.GetKey ("a")) {
				TURN_LEFT_CONT = true;
			}
			else {
				TURN_LEFT_CONT = false;
			}
			if (Input.GetKey ("s")) {
				GO_BACKWARD_CONT = true;
			}
			else {
				GO_BACKWARD_CONT = false;
			}
			if (Input.GetKey ("d")) {
				TURN_RIGHT_CONT = true;
			}
			else {
				TURN_RIGHT_CONT = false;
			}
		}
	}
}
