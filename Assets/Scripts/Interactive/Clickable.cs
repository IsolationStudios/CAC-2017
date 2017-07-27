using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;

/*
 * Zoomable object
 */

namespace Interactive{
	public class Clickable : MonoBehaviour {
		public int id = -2;
		public string name;
		public static float threshold = 0.001f;
		public static float speed = 5;

		private Vector3 savedCamPos;
		private SelectDisp selectDisp;
		private AudioSource talkSound;

		//Temp mouse control
		// Zoom in
		void OnMouseDown(){
			if(GameState.state == GameState.State.OPEN){
				savedCamPos = Camera.main.transform.position;

				CancelInvoke ();
				InvokeRepeating("MoveCamIn", 0, 0.01f);

				//Hide selection display
				selectDisp.HideSelectDisp();

				//Play sound
				talkSound.Play();

				GameState.state = GameState.State.ZOOMING;
			}
		}
		void OnMouseEnter(){
			if (GameState.state == GameState.State.OPEN) {
				selectDisp.ShowSelectDisp (name);
			}
		}
		void OnMouseExit(){
			if (GameState.state == GameState.State.OPEN) {
				selectDisp.HideSelectDisp ();
			}
		}

		protected virtual void Start(){
			selectDisp = GameObject.Find ("SelectDisp").GetComponent<SelectDisp>();
			talkSound = transform.GetComponent<AudioSource> ();
		}

		protected virtual void Update(){
			// Zoom out
			if (Input.GetKeyDown ("b") && GameState.state == GameState.State.ZOOM_DONE && GameState.lookingAt == id) {
				CancelInvoke ();
				InvokeRepeating("MoveCamOut", 0, 0.01f);

				GameState.state = GameState.State.ZOOMING;
			}
		}

		protected void MoveCamIn(){
			Vector3 target = transform.TransformPoint (new Vector3 (0, 0, 3));
			Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
															target,
															Time.deltaTime * speed);
			
			// Stops lerp
			if (ExtraMath.CheckCloseEnough (Camera.main.transform.position, target, threshold)) {
				CancelInvoke ();

				GameState.state = GameState.State.ZOOM_DONE;
				GameState.lookingAt = id;
			}
		}

		protected void MoveCamOut(){
			Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
															savedCamPos,
															Time.deltaTime * speed);

			// Stops lerp
			if (ExtraMath.CheckCloseEnough (Camera.main.transform.position, savedCamPos, threshold)) {
				CancelInvoke ();

				GameState.state = GameState.State.OPEN;
				GameState.lookingAt = -1;
			}
		}
	}
}