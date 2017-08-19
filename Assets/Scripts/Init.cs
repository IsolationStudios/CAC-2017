using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Initializes screen
 */

public class Init : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Screen.SetResolution (1920, 1080, false);
	}
}
