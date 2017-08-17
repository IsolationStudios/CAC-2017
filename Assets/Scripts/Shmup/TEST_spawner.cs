using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_spawner : MonoBehaviour {

	public GameObject enemybullet;
	float counter = 0;

	// Update is called once per frame
	void FixedUpdate () {
		Instantiate (enemybullet, new Vector3 (counter*0.2f, 0.1f, 0f), Quaternion.identity);
		counter++;
		counter %= 25;
	}
}
