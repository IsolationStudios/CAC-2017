using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingScript : MonoBehaviour {

	public GameObject player;

	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera.main.transform);
	}
}
