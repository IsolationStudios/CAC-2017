using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Dialogue box; activated upon spawn
 */

namespace GameUI{
	public class DialogueBox : MonoBehaviour {
		public string[] dArr;
		private int speed = 3;

		private string currD;
		private int dArrIndex = 0;
		private int dLetIndex = 0;
		private int dCounter = 0;

		private Text dText;
		private AudioSource dLetSound;
		private AudioSource dLineSound;

		void Start(){
			dText = (transform.Find ("Text")).transform.GetComponent<Text>();
			dText.text = "";

			dLetSound = transform.GetComponents<AudioSource> () [0];
			dLineSound = transform.GetComponents<AudioSource> () [1];
		}

		void Update() {
			// Go thru array of dialogue
			if (dArrIndex < dArr.Length) {
				//Load line
				if (dLetIndex == 0) {
					currD = dArr [dArrIndex];
				}
				// Move dialogue
				if (dLetIndex < currD.Length && dCounter % speed == 0) {
					dText.text = currD.Substring (0, dLetIndex+1);
					dLetIndex++;

					dLetSound.Play();
				}
				//Move line
				else if(Input.GetMouseButtonDown(0)) {
					dLetIndex = 0;
					dCounter = 0;
					dArrIndex++;

					if(dArrIndex < dArr.Length){
						dLineSound.Play();
					}
				}

				dCounter++;
			}
			//Kill when done
			else {
				GameState.state = GameState.State.DONE_TALKING;
				Destroy (gameObject);
			}
		}
	}
}