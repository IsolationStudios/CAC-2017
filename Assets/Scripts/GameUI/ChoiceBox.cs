using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Selectable box that spawns dialogue
 */

namespace GameUI{
	public class ChoiceBox : MonoBehaviour {
		public string[] dialogueArray;
		public string[] conds;
		public GameObject dBox;

		public void Chosen(){
			//Play dialogue
			var d = Instantiate (dBox);
			d.transform.SetParent(GameObject.Find ("Canvas").transform, false);
			d.GetComponent<DialogueBox> ().dArr = dialogueArray;
			d.GetComponent<DialogueBox> ().conds = conds;

			//Destroy all choice boxes
			foreach (GameObject box in GameObject.FindGameObjectsWithTag("ChoiceBox")) {
				Destroy (box);
			}
		}
	}
}