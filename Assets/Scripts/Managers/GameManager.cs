using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameUI;

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

		public int initX;
		public int initZ;
		public int initY;
		public bool isInit;

		public ArrayList floorLocs = new ArrayList();

		private Image fadeScreen;
		private SelectDisp selectDisp;

		public GameObject pauseMenu;

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}
		void Start(){
			// Carry over from scenes
			DontDestroyOnLoad (GameObject.Find("CarryOver"));

			fadeScreen = GameObject.Find ("FadeScreen").GetComponent<Image>();
			selectDisp = GameObject.Find ("SelectDisp").GetComponent<SelectDisp>();
		}

		public void LoadFromMem(){
			// Load from mem for now
			Load ();
			GoTo (currentScene);
			Destroy (GameObject.Find("Title"));
		}
		public void LoadNewGame(){
			GoTo ("2Droom01");
			Destroy (GameObject.Find("Title"));
		}

		void Update () {

			if(InputManager.instance.PAUSE && GameState.state == GameState.State.OPEN){
				GameState.state = GameState.State.MENU;
				Instantiate (pauseMenu, Vector3.zero, pauseMenu.transform.rotation, GameObject.Find("Canvas").transform);
			}

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
			if (Input.GetKeyDown ("6")) {
				GoTo ("cutscene_test");
				GameManager.instance.FadeFromBlack ();
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

		public void FadeToBlack(){
			fadeScreen.color = Color.black;
			fadeScreen.canvasRenderer.SetAlpha (0.0f);
			fadeScreen.CrossFadeAlpha(1.0f, 0.5f, false);
		}
		public void FadeFromBlack(){
			fadeScreen.color = Color.black;
			fadeScreen.canvasRenderer.SetAlpha (1.0f);
			fadeScreen.CrossFadeAlpha(0.0f, 0.5f, false);
		}
		public void HideDisp(){
			selectDisp.HideSelectDisp ();
		}

		// ------
		// Saving
		// ------
		public void Reset(){
			Save save = new Save ();

			//Write to file
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/gamesave.save");
			bf.Serialize (file, save);
			file.Close ();

			print ("reset: " + (Application.persistentDataPath + "/gamesave.save"));
		}

		public void Load(){
			if (File.Exists (Application.persistentDataPath + "/gamesave.save")) {
				//Deserialize
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/gamesave.save", FileMode.Open);
				Save save = (Save)bf.Deserialize (file);
				file.Close ();

				//Set vars
				currentScene = save.currentScene;
				initX = save.initX;
				initZ = save.initZ;
				initY = save.initY;
				InventorySystem.instance.Load (save);
			}
		}

		public void Save(){
			Save save = new Save ();

			save.currentScene = currentScene;
			save.initX = ExtraMath.RoundToNearest(GameObject.Find("Player").transform.position.x, 10);
			save.initZ = ExtraMath.RoundToNearest(GameObject.Find("Player").transform.position.z, 10);
			save.initY = ExtraMath.RoundToNearest(GameObject.Find("Player").transform.rotation.eulerAngles.y, 90);

			InventorySystem.instance.Save (save);

			//Write to file
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/gamesave.save");
			bf.Serialize (file, save);
			file.Close ();

			print ("saved to: " + (Application.persistentDataPath + "/gamesave.save"));
		}
	}
}
