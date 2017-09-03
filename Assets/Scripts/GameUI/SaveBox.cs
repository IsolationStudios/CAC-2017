using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Saves game when box is selected
 */

namespace GameUI{
	public class SaveBox : MonoBehaviour {
		public string[] dialogueArray;
		public string[] conds;
		public GameObject dBox;

		public void Chosen(){
			//Play dialogue
			var d = Instantiate (dBox);
			d.transform.SetParent(GameObject.Find ("Canvas").transform, false);
			d.GetComponent<DialogueBox> ().dArr = dialogueArray;
			d.GetComponent<DialogueBox> ().conds = conds;

			GameManager.instance.Save ();

			//Destroy all choice boxes
			foreach (GameObject box in GameObject.FindGameObjectsWithTag("ChoiceBox")) {
				Destroy (box);
			}
		}
	}
}