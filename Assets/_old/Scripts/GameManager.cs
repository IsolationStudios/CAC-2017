using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Modifies GameState variables
 */

public class GameManager : MonoBehaviour {

	void Awake(){
		GameState.playerState = GameState.State.Moving;
	}

	// Update is called once per frame
	void FixedUpdate () {

		//PC controls
		GameState.upDown = Input.GetKey ("w");
		GameState.leftDown = Input.GetKey ("a");
		GameState.downDown = Input.GetKey ("s");
		GameState.rightDown = Input.GetKey ("d");
		GameState.actionDown = Input.GetKey ("c");

	}
}
