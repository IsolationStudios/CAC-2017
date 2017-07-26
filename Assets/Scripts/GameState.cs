using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manage states
 */

public static class GameState {

	public enum State{
		OPEN,
		ZOOMING,
		ZOOM_DONE,
		TALKING,
		DONE_TALKING,
		MOVING
	};

	public static State state = State.OPEN;
	public static int lookingAt = -1;

}
