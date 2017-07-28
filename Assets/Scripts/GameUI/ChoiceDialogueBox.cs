using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI{
	public class ChoiceDialogueBox : DialogueBox {

		public GameObject[] choices;

		/*
		void Start(){
			foreach (GameObject c in choices) {
				c.tag = "ChoiceBox";
			}
		}
		*/

		override protected void Kill(){
			for (int i=0; i < choices.Length; i++) {
				var b = Instantiate (choices[i]);
				b.transform.SetParent(GameObject.Find ("Canvas").transform);
				b.transform.position = new Vector3 (100, i*100 + 100, 0);
				b.tag = "ChoiceBox";
			}
			Destroy (gameObject);
		}
	}
}