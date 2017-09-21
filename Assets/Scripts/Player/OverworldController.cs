using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player{
	public class OverworldController : MonoBehaviour {
		public string[] conds;

		void Start () {
			if (CondSatisfied ()) {
				FadeColor ();
			}	
		}

		// Checks if conditions are satisfied for passing
		bool CondSatisfied(){
			foreach(string s in conds){
				if ((int)InventorySystem.instance.GetType ().GetField (s).GetValue (InventorySystem.instance) == 0) {
					return false;
				}
			}

			return true;
		}

		void FadeColor(){
			transform.GetComponent<PostEffectScript> ().FadeBack ();
		}
	}
}