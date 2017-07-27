using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Displays what user is trying to select
 */

namespace GameUI{
	public class SelectDisp : MonoBehaviour {
		public int speed = 3;
		private Text selectDispText;
		private AudioSource selectSound;

		void Start(){
			selectDispText = transform.Find ("Text").GetComponent<Text> ();
			selectSound = transform.GetComponent<AudioSource> ();
		}

		void Update(){
			if (GameState.state == GameState.State.MOVING) {
				HideSelectDisp ();
			}
		}

		public void HideSelectDisp(){
			selectDispText.text = "";

			CancelInvoke ();
			InvokeRepeating("MoveUp", 0, 0.01f);
		}
		public void ShowSelectDisp(string name){
			selectDispText.text = name;
			selectSound.Play ();

			CancelInvoke ();
			InvokeRepeating("MoveDown", 0, 0.01f);
		}

		void MoveDown(){
			transform.localPosition = Vector3.Lerp (	transform.localPosition,
														new Vector3(0, 200, 0),
														Time.deltaTime * speed);
		}
		void MoveUp(){
			transform.localPosition = Vector3.Lerp (	transform.localPosition,
														new Vector3(0, 300, 0),
														Time.deltaTime * speed);
		}
	}
}
