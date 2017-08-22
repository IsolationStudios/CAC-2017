using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Excalamation particle when NPC is selected
 */

public class Exclamation : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.8f);
	}
}
