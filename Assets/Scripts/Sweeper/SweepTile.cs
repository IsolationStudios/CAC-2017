using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

/*
 * Tile in minesweeper minigame
 */

public class SweepTile : MonoBehaviour {

	bool isDug;
	public bool IsDug{
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

	void Update () {
		
	}

	void OnMouseDown(){
		if (!isDug && GameState.state == GameState.State.PUZZLE) {
			isDug = true;
			sr.sprite = dug;

			var d = Instantiate (dBox);
			d.transform.SetParent (GameObject.Find ("Canvas").transform, false);
			d.GetComponent<DialogueBox> ().dArr = dialogueArray;

			GameState.state = GameState.State.TALKING;
		}

	}
}
