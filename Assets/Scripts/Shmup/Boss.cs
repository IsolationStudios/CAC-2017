using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

/*
 * Bullet hell final boss
 */

public class Boss : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject dBox;
	public string[] dialogueArray;

	public GameObject enemybullet;
	public Timer timer;

	int counter = 0;
	int shootInterval = 10;

	void Start () {
		rb = transform.GetComponent<Rigidbody2D> ();
		timer = transform.GetComponent<Timer> ();
		Fire ();
	}

	// Choose a bullet pattern
	void Fire(){
		InitTestBullet ();
	}

	void Talk(){
		var d = Instantiate (dBox);
		d.transform.SetParent (GameObject.Find ("Canvas").transform, false);
		d.GetComponent<DialogueBox> ().dArr = dialogueArray;

		GameState.state = GameState.State.TALKING;
	}

	// ----------------
	//  Bullet patterns
	// ----------------
	void InitTestBullet(){
		transform.position = new Vector3 (-0.9f, transform.position.y, transform.position.z);
		counter = 0;

		timer.Reset ();
		for (int i = 0; i < 30; i++) {
			timer.SetTask (ShootRight, 50);
			timer.SetWait (10);
			timer.SetTask (ShootLeft, 50);
			timer.SetWait (10);
		}
	}
	void ShootRight(){
		//Movement
		if (transform.position.x < 1) {
			rb.AddForce (Vector2.right * rb.mass * 100);
		} else {
			CancelInvoke ("ShootRight");
		}

		if (counter % shootInterval == 0) {
			Instantiate (enemybullet, transform.position + Vector3.down*0.2f, Quaternion.identity);
		}

		counter++;
	}
	void ShootLeft(){
		//Movement
		if (transform.position.x > -1) {
			rb.AddForce (Vector2.left * rb.mass * 100);
		} else {
			CancelInvoke ("ShootLeft");
		}

		if (counter % shootInterval == 0) {
			Instantiate (enemybullet, transform.position + Vector3.down*0.2f, Quaternion.identity);
		}

		counter++;
	}
}
