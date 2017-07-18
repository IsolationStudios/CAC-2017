using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls dialogue for player
 */

public class PlayerTalk : MonoBehaviour {

	bool isTalkable;
	GameObject npc;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "NPC"){
			isTalkable = true;
			npc = col.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "NPC"){
			isTalkable = false;
			npc = null;
		}
	}

	void Update(){

		if (GameState.playerState != GameState.State.Talking && isTalkable && GameState.actionDown) {

			GameState.playerState = GameState.State.Talking;

			print (npc.GetComponent<NPCDialogue>().dialogueArray[0]);
		}

		// TEMP: get out of move lock
		else if(Input.GetKeyDown("space")){
			GameState.playerState = GameState.State.Moving;
		}
	}
}
