using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive{
	public class NPC : Clickable {

		public string[] dialogueArray;
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

		void Talk(){
			var d = Instantiate (dBox);
			d.transform.SetParent(GameObject.Find ("Canvas").transform);
			d.GetComponent<DialogueBox> ().dArr = dialogueArray;
		}
	}
}