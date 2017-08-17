using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Controls minesweep tiles
 */

namespace Sweeper{
	public class SweeperController : MonoBehaviour {
		float mult = 0.2f;
		public GameObject sweepTile;
		GameObject[,] sweepTileArray;

		// Use this for initialization
		void Start () {
			sweepTileArray = new GameObject[5, 5];

			for(int i=0; i < 5; i++){
				for(int j=0; j < 5; j++){
					sweepTileArray [i, j] = Instantiate (sweepTile, new Vector3((i-2)*mult, (j-2)*mult, 0), Quaternion.Euler(0, 0, 0));
				}
			}
		}

		void Update () {
			if (GameState.state == GameState.State.DONE_TALKING) {
				GameState.state = GameState.State.PUZZLE;

				//Check done
				bool allDug = true;
				for(int i=0; i < 5; i++){
					for(int j=0; j < 5; j++){
						allDug &= sweepTileArray [i, j].gameObject.GetComponent<SweepTile> ().IsDug;
					}
				}

				// Win
				// TEMP: GO BACK TO ROOM 1
				if (allDug) {
					GameState.state = GameState.State.OPEN;
					GameManager.instance.GoTo ("room01");
				}
			}
		}
	}
}
