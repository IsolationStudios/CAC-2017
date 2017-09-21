using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Managers;

/*
 * Button controls for title
 */

public class TitleControl : MonoBehaviour {

	void Start(){
		GameState.state = GameState.State.MENU;
	}

	public void NewGame(){
		GameManager.instance.LoadNewGame ();
		GameManager.instance.FadeFromBlack ();
		GameState.state = GameState.State.OPEN;
	}

	public void ContGame(){
		GameManager.instance.LoadFromMem ();
		GameManager.instance.FadeFromBlack ();
		GameState.state = GameState.State.OPEN;
	}

	public void Credits(){
	}
}
