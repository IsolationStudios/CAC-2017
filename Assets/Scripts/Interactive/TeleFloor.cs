using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;
using Managers;

/*
 * Floor that can be teleported to
 */

namespace Interactive{
	public class TeleFloor : Floor {
		public GameObject targetFloor;

		public AudioClip moveSound;

		// Temp mouse control
		void Start(){
			
		}
			
		void Update(){
			if (ExtraMath.CheckCloseEnoughXZ (Camera.main.transform.position, transform.position, 1f)) {
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
	}
}