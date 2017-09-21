using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Managers;

/*
 * Dialogue box; activated upon spawn
 */

namespace GameUI{
	public class DialogueBox : MonoBehaviour {
		public string[] dArr;
		private int speed;
		private int NORM_SPEED;
		private int SLOW_SPEED;

		private int startIndex = 6;
		private string currD;
		protected int dArrIndex = 0;
		private int dLetIndex;
		private int dCounter = 0;

		private Text dText;
		private GameObject arrow;
		float arrowVal = 0.3f;

		private CharPortrait charPort;
		private ImgScreen imgScreen;

		public AudioClip dLetSound;
		public AudioClip dLineSound;
		public AudioClip exitSound;

		public string[] conds;
		public string gotoScene;

		void Start(){
			dLetIndex = startIndex;
			dText = (transform.Find ("Text")).transform.GetComponent<Text>();
			dText.text = "";

			arrow = transform.Find ("Arrow").gameObject;
			arrow.SetActive (false);

			if (Application.isEditor) {
				NORM_SPEED = 2;
				SLOW_SPEED = 20;
			}
			else {
				NORM_SPEED = 2;
				SLOW_SPEED = 20;
			}
			speed = NORM_SPEED;

			charPort = GameObject.Find ("CharPortrait").GetComponent<CharPortrait>();
			imgScreen = GameObject.Find ("ImgScreen").GetComponent<ImgScreen>();
		}

		void Update() {
			// Go thru array of dialogue
			if (dArrIndex < dArr.Length) {
				MoveText ();
			}
			//Kill when done
			else {
				Kill();
			}
		}

		protected void MoveText(){
			//Load line
			if (dLetIndex == startIndex) {
				currD = dArr [dArrIndex];

				charPort.SetPortrait (int.Parse(dArr [dArrIndex].Substring(0, 2)));
				imgScreen.SetScreen (int.Parse (dArr [dArrIndex].Substring (3, 2)));
			}

			// Move dialogue
			if (dLetIndex < currD.Length && dCounter % speed == 0) {
				dText.text = currD.Substring (startIndex, dLetIndex+1 - startIndex);
				dLetIndex++;

				//Slow punctuation
				Regex reg = new Regex(@"\.|\?|\,|\!");
				if (reg.IsMatch(currD [dLetIndex-1].ToString()) && speed == NORM_SPEED) {
					dCounter = 1;
					speed = SLOW_SPEED;
				}
				else if(!reg.IsMatch(currD [dLetIndex-1].ToString())){
					speed = NORM_SPEED;
				}

				//Prevent cutoff
				if(dCounter > 10)
					SoundManager.instance.PlaySFX(dLetSound);
			}
			//Move line
			else if(Input.GetMouseButtonDown(0)) {
				dLetIndex = startIndex;
				dCounter = 0;
				dArrIndex++;
				speed = NORM_SPEED;

				if(dArrIndex < dArr.Length){
					SoundManager.instance.PlaySFX(dLineSound);
				}
			}

			//Display arrow
			if (dLetIndex >= currD.Length) {
				arrow.SetActive (true);
				arrow.transform.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0, arrowVal);
				if (dCounter % 20 == 0) {
					arrowVal *= -1;
				}
			} else {
				arrow.SetActive (false);
				arrow.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2(arrow.transform.GetComponent<RectTransform> ().anchoredPosition.x, -20);
			}

			dCounter++;
		}

		protected virtual void Kill(){

			// Set bools
			foreach(string s in conds){
				InventorySystem.instance.GetType ().GetField (s).SetValue (InventorySystem.instance, 1);
			}

			// Redirect to sceen
			if (gotoScene != "") {
				GameManager.instance.FadeFromBlack ();
				GameManager.instance.GoTo (gotoScene);
			}

			SoundManager.instance.PlaySFX(exitSound);
			charPort.HideDisp();
			GameState.state = GameState.State.DONE_TALKING;
			Destroy (gameObject);
		}
	}
}