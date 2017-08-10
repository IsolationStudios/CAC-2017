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
				b.transform.SetParent(GameObject.Find ("Canvas").transform, false);
				b.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-100, 100 + 100*i);
				b.tag = "ChoiceBox";
			}
			Destroy (gameObject);
		}
	}
}