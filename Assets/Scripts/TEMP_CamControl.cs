using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_CamControl : MonoBehaviour {
	int counter;

	// Update is called once per frame
	void Update () {
		if (GameState.state == GameState.State.OPEN) {
			if (Input.GetKeyDown ("d")) {
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


}
