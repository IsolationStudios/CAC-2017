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

		private string currD;
		protected int dArrIndex = 0;
		private int dLetIndex = 0;
		private int dCounter = 0;

		private Text dText;

		public AudioClip dLetSound;
		public AudioClip dLineSound;
		public AudioClip exitSound;

		void Start(){
			dText = (transform.Find ("Text")).transform.GetComponent<Text>();
			dText.text = "";
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
			if (dLetIndex == 0) {
				currD = dArr [dArrIndex];
			}

			// Move dialogue
			if (dLetIndex < currD.Length && dCounter % speed == 0) {
				dText.text = currD.Substring (0, dLetIndex+1);
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
				dLetIndex = 0;
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

			GameState.state = GameState.State.DONE_TALKING;
			Destroy (gameObject);
		}
	}
}