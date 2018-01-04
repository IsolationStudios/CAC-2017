using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Serializable save object
 */

[System.Serializable]
public class Save {
	// Game data
	public string currentScene = "2Droom01";
	public int initX;
	public int initZ;
	public int initY;

	// Inventory data
	// Don't forget to add data to InventorySystem
	public int hasCat;

	public int trauma1Done;
	public int trauma2Done;
	public int trauma3Done;
	public int trauma4Done;

	public int room02Open;
	public int ranIntro;
	public int talkedToMom;
	public int portalDiscovered;
	//TODO: add invent vars
}