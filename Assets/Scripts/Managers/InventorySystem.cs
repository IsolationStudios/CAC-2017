using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers{
	public class InventorySystem : MonoBehaviour {
		public static InventorySystem instance;

		// Inventory data
		public int hasCat;
		// TODO: add data

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		public void Reset(){
			PlayerPrefs.SetInt ("hasCat", 0);
		}

		public void Load(){
			//TODO: load invent
			hasCat = PlayerPrefs.GetInt ("hasCat", 0);
		}

		public void Save(){
			//TODO: save invent
			PlayerPrefs.SetInt ("hasCat", hasCat);
		}
	}
}
