using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Records inventory bools
 */

namespace Managers{
	public class InventorySystem : MonoBehaviour {
		public static InventorySystem instance;

		// Inventory data
		public int hasCat;
		public int room02Open;

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		public void Reset(){
			PlayerPrefs.SetInt ("hasCat", 0);
			PlayerPrefs.SetInt ("room02Open", 0);
		}

		public void Load(){
			//TODO: load invent
			hasCat = PlayerPrefs.GetInt ("hasCat", 0);
			room02Open = PlayerPrefs.GetInt ("room02Open", 0);
		}

		public void Save(){
			//TODO: save invent
			PlayerPrefs.SetInt ("hasCat", hasCat);
			PlayerPrefs.SetInt ("room02Open", room02Open);
		}
	}
}
