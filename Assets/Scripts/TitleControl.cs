using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Managers;

/*
 * Button controls for title
 */

public class TitleControl : MonoBehaviour {

	public void NewGame(){
		GameManager.instance.LoadNewGame ();
	}

	public void ContGame(){
		GameManager.instance.LoadFromMem ();
	}

	public void Credits(){
	}
}
