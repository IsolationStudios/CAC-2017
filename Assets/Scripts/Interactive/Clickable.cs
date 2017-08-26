using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;
using Managers;

/*
 * Zoomable object
 */

namespace Interactive{
	public class Clickable : MonoBehaviour {
		public int id = -2;
		public string name;
		public static float threshold = 0.001f;
		public static float speed = 10;

		public GameObject exclamation;

		private Vector3 savedCamPos;
		private SelectDisp selectDisp;

		public AudioClip talkSound;

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
				SoundManager.instance.PlaySFX(talkSound);

				//Show stars
				Instantiate (exclamation, this.transform.position + Vector3.up, Quaternion.identity);

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
			Vector3 target = transform.Find("LookTarget").transform.TransformPoint (new Vector3 (0, 0, 3));
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

				//Round position
				//Adding 0.1 cause weird math...
				Camera.main.transform.position = new Vector3(
					ExtraMath.RoundToNearest(Camera.main.transform.position.x, 10) + 0.01f,
					Camera.main.transform.position.y,
					ExtraMath.RoundToNearest(Camera.main.transform.position.z, 10) + 0.01f
				);

				GameState.state = GameState.State.OPEN;
				GameState.lookingAt = -1;
			}
		}
	}
}