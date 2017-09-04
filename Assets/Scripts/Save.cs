using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Serializable save object
 */

[System.Serializable]
public class Save {
	// Game data
	public string currentScene = "room01";
	public int initX;
	public int initZ;
	public int initY;

	// Inventory data
	public int hasCat;
	public int room02Open;
	//TODO: add invent vars
}