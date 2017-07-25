using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive{
	public class DialogueBox : MonoBehaviour {

		public string[] dArr;

		private string currD;
		private int dArrIndex = 0;
		private int dLetIndex = 0;
		private Text dText;

		void Start(){
			dText = (transform.Find ("Text")).transform.GetComponent<Text>();

		}

		void Update(){
			// Go thru array of dialogue
			if (dArrIndex < dArr.Length) {

				//Load line
				if (dLetIndex == 0) {
					currD = dArr [dArrIndex];
				}

				// Move dialogue
				if (dLetIndex < currD.Length) {
					dText.text = currD.Substring (0, dLetIndex+1);
					dLetIndex++;
				}
				//Move line
				else if(Input.GetMouseButtonDown(0)) {
					dLetIndex = 0;
					dArrIndex++;
				}

			}
			//Kill when done
			else {
				GameState.state = GameState.State.DONE_TALKING;
				Destroy (gameObject);
			}
		}
	}
}