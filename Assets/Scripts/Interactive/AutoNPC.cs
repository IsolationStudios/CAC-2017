using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

/*
 * Clickable with dialogue that talks when loaded
 * Branching choices added with a Choice empty object containing ChoiceBoxes
 * Enter names of inventory conds to change in conds
 */

namespace Interactive{
	public class AutoNPC : NPC {
		void Start(){
			GameState.state = GameState.State.TALKING;
			Talk ();
		}
	}
}