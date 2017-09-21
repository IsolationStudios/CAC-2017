using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

/*
 * Tile in minesweeper minigame
 */

namespace Sweeper{
	public class SweepTile : MonoBehaviour {
		int isDug = 0;
		public int IsDug{
			get{
				return isDug;
			}
		}

		public Sprite notDug;
		public Sprite dug;
		SpriteRenderer sr;

		public GameObject dBox;
		public string[] dialogueArray;

		void Start () {
			sr = transform.GetComponent<SpriteRenderer> ();
			sr.sprite = notDug;
		}

		void OnMouseDown(){
			if (isDug == 0 && GameState.state == GameState.State.PUZZLE) {
				isDug = 1;
				sr.sprite = dug;

				var d = Instantiate (dBox);
				d.transform.SetParent (GameObject.Find ("Canvas").transform, false);
				d.GetComponent<DialogueBox> ().dArr = dialogueArray;

				GameState.state = GameState.State.TALKING;
			}
		}
	}
}
