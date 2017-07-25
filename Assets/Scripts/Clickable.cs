using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	private Vector3 savedCamPos;

	//Temp mouse control
	void OnMouseDown(){

		savedCamPos = Camera.main.transform.position;

		CancelInvoke ();
		InvokeRepeating("MoveCamIn", 0, 0.01f);

	}

	void OnMouseUp(){
		CancelInvoke ();
		InvokeRepeating("MoveCamOut", 0, 0.01f);
	}

	void MoveCamIn(){
		Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
														transform.TransformPoint(new Vector3(0, 0, 2)),
														Time.deltaTime);

		if (CheckCloseEnough (Camera.main.transform.position, transform.TransformPoint (new Vector3 (0, 0, 2)))) {
			CancelInvoke ();
		}

		//print ("moving in");
	}

	void MoveCamOut(){
		Camera.main.transform.position = Vector3.Lerp (	Camera.main.transform.position,
														savedCamPos,
														Time.deltaTime);

		if (CheckCloseEnough (Camera.main.transform.position, savedCamPos)) {
			CancelInvoke ();
		}
	}

	static bool CheckCloseEnough(Vector3 a, Vector3 b){
		return (Mathf.Abs (a.x - b.x) < 0.01 &&
		    Mathf.Abs (a.y - b.y) < 0.01 &&
		    Mathf.Abs (a.z - b.z) < 0.01);
			
	}
}
