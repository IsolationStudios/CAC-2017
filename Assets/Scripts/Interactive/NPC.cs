using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

/*
 * Clickable with dialogue
 * Branching choices added with a Choice empty object containing ChoiceBoxes
 * Enter names of inventory conds to change in conds
 */

namespace Interactive{
	public class NPC : Clickable {
		public string[] dialogueArray;
		public string[] conds;
		public string gotoScene;
		public GameObject dBox;

		protected override void Update(){
			base.Update ();

			if (GameState.state == GameState.State.ZOOM_DONE && GameState.lookingAt == id) {
				GameState.state = GameState.State.TALKING;
				Talk ();
			}
			else if (GameState.state == GameState.State.DONE_TALKING && GameState.lookingAt == id) {
				MoveCamOut ();
			}
		}

		protected virtual void Talk(){
			var d = Instantiate (dBox);
			d.transform.SetParent(GameObject.Find ("Canvas").transform, false);
			d.GetComponent<DialogueBox> ().dArr = dialogueArray;
			d.GetComponent<DialogueBox> ().conds = conds;
			d.GetComponent<DialogueBox> ().gotoScene = gotoScene;

			//Check for choices
			Transform choiceParent = transform.Find ("Choices");
			if (choiceParent) {
				GameObject[] choices = new GameObject[choiceParent.transform.childCount];
				for(int i=0; i < choices.Length; i++){
					choices [i] = choiceParent.transform.GetChild (i).gameObject;
				}
				d.GetComponent<ChoiceDialogueBox> ().choices = choices;
			}
		}
	}
}