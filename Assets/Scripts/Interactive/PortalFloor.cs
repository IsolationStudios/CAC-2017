using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;
using Managers;

/*
 * Floor that can be teleported to
 */

namespace Interactive{
	[System.Obsolete("Legacy from 3D")]
	public class PortalFloor : TeleFloor {
		public string scene;

		override protected void MoveToFloor() {
			SoundManager.instance.PlaySFX (moveSound);

			GameManager.instance.GoTo (scene);

			GameState.state = GameState.State.OPEN;
			GameState.lookingAt = -1;
		}
	}
}