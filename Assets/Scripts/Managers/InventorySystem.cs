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
		// Don't forget to add bool to Save
		public int hasCat;
		public int room02Open;
		public int trauma1Done;
		public int trauma2Done;
		public int trauma3Done;
		public int trauma4Done;
		//TODO: add invent vars

		public int talkedToMom;

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
			trauma1Done = save.trauma1Done;
			trauma2Done = save.trauma2Done;
			trauma3Done = save.trauma3Done;
			trauma4Done = save.trauma4Done;
			talkedToMom = save.talkedToMom;
		}

		public void Save(Save save){
			//TODO: save invent
			save.hasCat = hasCat;
			save.room02Open = room02Open;
			save.trauma1Done = trauma1Done;
			save.trauma2Done = trauma2Done;
			save.trauma3Done = trauma3Done;
			save.trauma4Done = trauma4Done;
			save.talkedToMom = talkedToMom;
		}
	}
}
