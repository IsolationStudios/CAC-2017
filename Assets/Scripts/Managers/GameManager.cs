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

			if (Input.GetKeyDown ("q")) {
				GoTo ("comboLock");
			}
			// end debug
		}

		public void GoTo(string scene){
			SceneManager.LoadScene (scene);
		}
	}
}
