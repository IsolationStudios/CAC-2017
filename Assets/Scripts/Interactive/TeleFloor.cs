using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;

/*
 * Floor that can be teleported to
 */

namespace Interactive{
	public class TeleFloor : MonoBehaviour {
		public GameObject targetFloor;

		private Image fadeScreen;
		private SelectDisp selectDisp;

		public AudioClip moveSound;

		// Temp mouse control
		void Start(){
			fadeScreen = GameObject.Find ("FadeScreen").GetComponent<Image>();
			selectDisp = GameObject.Find ("SelectDisp").GetComponent<SelectDisp>();
		}

		void OnMouseDown(){
			if(GameState.state == GameState.State.OPEN && !ExtraMath.CheckCloseEnoughXZ(transform.position, Camera.main.transform.position, 0.001f)){
				MoveToFloor ();
				FadeFromBlack ();
			}
		}

		void MoveToFloor() {
			SoundManager.instance.PlaySFX (moveSound);
			Camera.main.transform.position = new Vector3 (
													targetFloor.transform.position.x,
													Camera.main.transform.position.y,
													targetFloor.transform.position.z
												);

			GameState.state = GameState.State.OPEN;
			GameState.lookingAt = -1;
		}

		void FadeToBlack(){
			fadeScreen.color = Color.black;
			fadeScreen.canvasRenderer.SetAlpha (0.0f);
			fadeScreen.CrossFadeAlpha(1.0f, 0.5f, false);
		}
		void FadeFromBlack(){
			fadeScreen.color = Color.black;
			fadeScreen.canvasRenderer.SetAlpha (1.0f);
			fadeScreen.CrossFadeAlpha(0.0f, 0.5f, false);
		}
	}
}