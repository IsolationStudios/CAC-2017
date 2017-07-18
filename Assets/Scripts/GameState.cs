using System.Collections;
using System.Collections.Generic;

/*
 * Records input and game state
 */

public static class GameState {

	// Player states
	// Replace with FSM???
	public enum State{
		Idle,
		Moving,
		Talking
	};
	public static State playerState;

	public static bool rightDown;
	public static bool downDown;
	public static bool leftDown;
	public static bool upDown;
	public static bool actionDown;

	public static int GetAxis(string axis){
		if (axis == "Horizontal") {
			if (rightDown) {
				return 1;
			} else if (leftDown) {
				return -1;
			} else {
				return 0;
			}
		} else if (axis == "Vertical") {
			if (upDown) {
				return 1;
			} else if (downDown) {
				return -1;
			} else {
				return 0;
			}
		} else {
			return 0;
		}
	}
}
