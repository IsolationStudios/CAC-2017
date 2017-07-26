using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages game
 */

public class GameManager : MonoBehaviour {

	public GameState.State s;
	public int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// TEMP: debug
		s = GameState.state;
		id = GameState.lookingAt;
	}
}
