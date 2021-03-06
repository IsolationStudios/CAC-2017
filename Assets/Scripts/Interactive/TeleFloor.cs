using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;
using Managers;

/*
 * Floor that can be teleported to
 */

namespace Interactive{
	[System.Obsolete("Legacy from 3D")]
	public class TeleFloor : Floor {
		public GameObject targetFloor;
		public AudioClip moveSound;
		public string[] conds;

		void Update(){
			if (ExtraMath.CheckCloseEnoughXZ (Camera.main.transform.position, transform.position, 1f) && CondSatisfied()) {
				if(GameState.state == GameState.State.OPEN && !ExtraMath.CheckCloseEnoughXZ(transform.position, Camera.main.transform.position, 0.001f)){
					MoveToFloor ();
					GameManager.instance.FadeFromBlack ();
				}
			}
		}

		protected virtual void MoveToFloor() {
			SoundManager.instance.PlaySFX (moveSound);
			Camera.main.transform.position = new Vector3 (
													targetFloor.transform.position.x,
													Camera.main.transform.position.y,
													targetFloor.transform.position.z
												);

			GameState.state = GameState.State.OPEN;
			GameState.lookingAt = -1;
		}

		// Checks if conditions are satisfied for passing
		bool CondSatisfied(){
			foreach(string s in conds){
				if ((int)InventorySystem.instance.GetType ().GetField (s).GetValue (InventorySystem.instance) == 0) {
					return false;
				}
			}

			return true;
		}
	}
}