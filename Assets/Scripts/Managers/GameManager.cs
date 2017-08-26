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
		public string currentScene;
		public string previousScene;

		public ArrayList floorLocs = new ArrayList();

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}
		void Start(){
			// Carry over from scenes
			DontDestroyOnLoad (GameObject.Find("CarryOver"));

			// Load from mem for now
			Load ();
			GoTo (currentScene);
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

			previousScene = currentScene;
			currentScene = scene;
		}

		// Checks if loc is a floor
		public bool CheckInVec(Vector3 vec){
			foreach (Vector3 v in floorLocs) {
				if(ExtraMath.CheckCloseEnoughXZ(v, vec, 1f)){
					return true;
				}
			}
			return false;
		}

		// ------
		// Saving
		// ------
		public void Reset(){
			PlayerPrefs.SetString("currentScene", "room01");
			InventorySystem.instance.Reset ();
		}

		public void Load(){
			currentScene = PlayerPrefs.GetString("currentScene", "room01");
			InventorySystem.instance.Load ();
		}

		public void Save(){
			PlayerPrefs.SetString("currentScene", currentScene);
			InventorySystem.instance.Save ();
		}
	}
}
