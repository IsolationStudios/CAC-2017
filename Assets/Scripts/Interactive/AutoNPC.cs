using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;
using Managers;

/*
 * Clickable with dialogue that talks when loaded
 * Branching choices added with a Choice empty object containing ChoiceBoxes
 * Enter names of inventory conds to change in conds
 */

namespace Interactive{
	public class AutoNPC : NPC {

		public string eventID;

		void Start(){
			GameState.state = GameState.State.TALKING;
			Talk ();
		}
	}
}