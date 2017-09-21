using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.SceneManagement;

/*
 * Controls pause screen
 */

public class PauseControl : MonoBehaviour {

	public void Cont(){
		GameManager.instance.HideDisp ();
		GameState.state = GameState.State.OPEN;
		Destroy (transform.parent.gameObject);
	}

	public void BackToTitle(){
		Destroy (GameObject.Find("CarryOver"));
		SceneManager.LoadScene ("title");
	}
}
