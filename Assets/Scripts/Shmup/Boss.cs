using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;
using UnityEngine.UI;

/*
 * Bullet hell final boss
 */

public class Boss : MonoBehaviour {

	public int hp;

	Rigidbody2D rb;

	public GameObject dBox;
	public string[] dialogueArray;

	public GameObject enemybullet;
	public Timer timer;

	public Text hpText;

	int counter = 0;
	int shootInterval = 10;

	void Start () {
		rb = transform.GetComponent<Rigidbody2D> ();
		timer = transform.GetComponent<Timer> ();
		Fire ();
	}

	void Update(){
		DispHPBars ();
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

	void DispHPBars(){
		string hpt = "";
		for(int i=0; i < hp; i+=2){
			hpt += "|";
		}
		hpText.text = hpt;
	}

	// --------------------------------------------------------------------------------------------------------------------------
	//  														Bullet patterns
	// --------------------------------------------------------------------------------------------------------------------------
	void InitTestBullet(){
		transform.position = new Vector3 (0, transform.position.y, transform.position.z);
		counter = 0;

		timer.Reset ();

		for (int i = 0; i < 30; i++) {
			
			timer.SetTask (MoveRight, 50);
			timer.SetWait (10);
			timer.SetTask (ShootCircle, 10);
			timer.SetWait (10);
			timer.SetTask (MoveLeft, 50);
			timer.SetWait (10);
			timer.SetTask (ShootCircle, 10);
			timer.SetWait (10);
			timer.SetTask (MoveCenter, 50);
			timer.SetTask (ShootArch, 500);
			timer.SetWait (100);
			timer.SetTask (Talk, 1);
		}
	}

	void MoveRight(){
		//Movement
		if (transform.position.x < 1) {
			rb.AddForce (Vector2.right * rb.mass * 100);
		} else {
			CancelInvoke ("ShootRight");
		}
	}
	void MoveLeft(){
		//Movement
		if (transform.position.x > -1) {
			rb.AddForce (Vector2.left * rb.mass * 100);
		} else {
			CancelInvoke ("ShootLeft");
		}
	}
	void MoveCenter(){
		//Movement
		if (transform.position.x > 0.01) {
			rb.AddForce (Vector2.left * rb.mass * 100);
		}
		else if(transform.position.x < -0.01){
			rb.AddForce (Vector2.right * rb.mass * 100);
		} else {
			transform.position = new Vector3 (0, transform.position.y, transform.position.z);
			CancelInvoke ("MoveCenter");
		}
	}

	void ShootRight(){
		MoveRight ();

		if (counter % shootInterval == 0) {
			Instantiate (enemybullet, transform.position + Vector3.down*0.2f, Quaternion.identity);
		}

		counter++;
	}
	void ShootLeft(){
		MoveLeft ();

		if (counter % shootInterval == 0) {
			Instantiate (enemybullet, transform.position + Vector3.down*0.2f, Quaternion.identity);
		}

		counter++;
	}
	void  ShootArch(){
		if (counter % shootInterval == 0) {
			for (int i = 0; i < 4; i++) {
				Instantiate (enemybullet, transform.position, Quaternion.Euler (0, 0, 90 * i + counter));
			}
		}
		counter++;
	}
	void  ShootCircle(){
		if (counter % shootInterval == 0) {
			for (int i = 0; i < 30; i++) {
				Instantiate (enemybullet, transform.position, Quaternion.Euler (0, 0, 360/30 * i));
			}
		}
		counter++;
	}

	void  TheWall(){
		if (counter % shootInterval == 0) {
			for (int i = 0; i < 10; i++) {
				Instantiate (enemybullet, new Vector3(-1 + 2f/10*i, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		else if(counter % shootInterval == 5){
			for (int i = 0; i < 10; i++) {
				Instantiate (enemybullet, new Vector3(-.9f + 2f/10*i, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		counter++;
	}
}
