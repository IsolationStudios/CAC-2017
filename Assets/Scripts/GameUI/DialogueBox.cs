using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

/*
 * Dialogue box; activated upon spawn
 */

namespace GameUI{
	public class DialogueBox : MonoBehaviour {
		public string[] dArr;
		private int speed = 3;

		private int startIndex = 3;
		private string currD;
		protected int dArrIndex = 0;
		private int dLetIndex;
		private int dCounter = 0;

		private Text dText;

		private CharPortrait charPort;

		public AudioClip dLetSound;
		public AudioClip dLineSound;
		public AudioClip exitSound;

		void Start(){
			dLetIndex = startIndex;
			dText = (transform.Find ("Text")).transform.GetComponent<Text>();
			dText.text = "";

			charPort = GameObject.Find ("CharPortrait").GetComponent<CharPortrait>();
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
			}

			// Move dialogue
			if (dLetIndex < currD.Length && dCounter % speed == 0) {
				dText.text = currD.Substring (startIndex, dLetIndex+1 - startIndex);
				dLetIndex++;

				//Slow punctuation
				Regex reg = new Regex(@"\.|\?|\,|\!");
				if (reg.IsMatch(currD [dLetIndex-1].ToString()) && speed == 3) {
					dCounter = 1;
					speed = 20;
				} else if(!reg.IsMatch(currD [dLetIndex-1].ToString())){
					speed = 3;
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
				speed = 3;

				if(dArrIndex < dArr.Length){
					SoundManager.instance.PlaySFX(dLineSound);
				}
			}

			dCounter++;
		}

		protected virtual void Kill(){
			SoundManager.instance.PlaySFX(exitSound);

			charPort.HideDisp();

			GameState.state = GameState.State.DONE_TALKING;
			Destroy (gameObject);
		}
	}
}