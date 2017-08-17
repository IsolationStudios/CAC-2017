using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Manages game
 */

namespace Managers {
	public class GameManager : MonoBehaviour {
		public static GameManager instance;
		public GameState.State s;
		public int id;

		public ArrayList floorLocs = new ArrayList();

		void Start () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);

			// Carry over from scenes
			DontDestroyOnLoad (GameObject.Find("CarryOver"));
			GoTo ("room01");
		}

		void Update () {

			// TEMP: debug
			s = GameState.state;
			id = GameState.lookingAt;

			if (Input.GetKeyDown ("1")) {
				GoTo ("comboLock");
				GameState.state = GameState.State.PUZZLE;
			}
			if (Input.GetKeyDown ("2")) {
				GoTo ("roseMaze");
				GameState.state = GameState.State.PUZZLE;
			}
			if (Input.GetKeyDown ("3")) {
				GoTo ("normMaze");
				GameState.state = GameState.State.PUZZLE;
			}
			if (Input.GetKeyDown ("4")) {
				GoTo ("sweeper");
				GameState.state = GameState.State.PUZZLE;
			}
			if (Input.GetKeyDown ("5")) {
				GoTo ("shmup");
				GameState.state = GameState.State.PUZZLE;
			}
			// end debug
		}

		public void GoTo(string scene){
			floorLocs.Clear ();
			SceneManager.LoadScene (scene);
		}

		public bool CheckInVec(Vector3 vec){

			foreach (Vector3 v in floorLocs) {
				if(ExtraMath.CheckCloseEnoughXZ(v, vec, 1f)){
					return true;
				}
			}
			return false;
		}
	}
}
