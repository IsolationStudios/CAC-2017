using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive{
	public class Clickable : MonoBehaviour {

		private Vector3 savedCamPos;
		public int id = -2;

		//Temp mouse control

		// Zoom in
		void OnMouseDown(){

			if(GameState.state == GameState.State.OPEN){
				savedCamPos = Camera.main.transform.position;

				CancelInvoke ();
				InvokeRepeating("MoveCamIn", 0, 0.01f);

				GameState.state = GameState.State.ZOOMING;
			}
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
															Time.deltaTime);

			// Stops lerp
			if (CheckCloseEnough (Camera.main.transform.position, target)) {
				CancelInvoke ();

				GameState.state = GameState.State.ZOOM_DONE;
				GameState.lookingAt = id;
			}
		}

		protected void MoveCamOut(){
			Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
															savedCamPos,
															Time.deltaTime);

			// Stops lerp
			if (CheckCloseEnough (Camera.main.transform.position, savedCamPos)) {
				CancelInvoke ();

				GameState.state = GameState.State.OPEN;
				GameState.lookingAt = -1;
			}
		}

		static bool CheckCloseEnough(Vector3 a, Vector3 b){
			return (Mathf.Abs (a.x - b.x) < 0.01 &&
			    Mathf.Abs (a.y - b.y) < 0.01 &&
			    Mathf.Abs (a.z - b.z) < 0.01);
				
		}
	}
}