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
		//TODO: add invent vars

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		public void Load(Save save){
			//TODO: load invent
			hasCat = save.hasCat;
			room02Open = save.room02Open;
		}

		public void Save(Save save){
			//TODO: save invent
			save.hasCat = hasCat;
			save.room02Open = room02Open;
		}
	}
}
