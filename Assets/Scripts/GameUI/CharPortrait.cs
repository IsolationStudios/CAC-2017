using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Displays character portrait
 * Portrait set in dialogue with ##:<imgscreen>:<text> where ## is the portrait index and <text> is the dialogue
 */

namespace GameUI{
	public class CharPortrait : MonoBehaviour {
		public int speed = 2;
		public Sprite[] portraits;

		private int currentPortrait = -1;

		public void SetPortrait(int n){
			transform.GetComponent<Image> ().sprite = portraits [n];

			if (currentPortrait != n) {
				ShowDisp ();
			}

			currentPortrait = n;
		}

		public void HideDisp(){
			CancelInvoke ();
			currentPortrait = -1;
			InvokeRepeating("MoveOut", 0, 0.01f);
		}
		public void ShowDisp(){
			CancelInvoke ();
			transform.localPosition = new Vector3 (-600, 0, 0);
			InvokeRepeating("MoveIn", 0, 0.01f);
		}

		void MoveIn(){
			transform.localPosition = Vector3.Lerp (	transform.localPosition,
														new Vector3(-200, 0, 0),
														Time.deltaTime * speed);
		}
		void MoveOut(){
			transform.localPosition = Vector3.Lerp (	transform.localPosition,
														new Vector3(-600, 0, 0),
														Time.deltaTime * speed);
		}
	}
}
