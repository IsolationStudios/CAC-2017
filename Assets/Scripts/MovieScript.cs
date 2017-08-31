using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Managers;

public class MovieScript : MonoBehaviour {

	public VideoPlayer vp;
	public string gotoScene;

	private bool isFaded;

	// Update is called once per frame
	void Update () {
		if (!vp.isPlaying) {
			GameManager.instance.GoTo (gotoScene);
			GameState.state = GameState.State.OPEN;
			GameManager.instance.FadeFromBlack ();
		}
		else if ((int)vp.frame + 5 > (int)vp.frameCount && !isFaded) {
			GameManager.instance.FadeToBlack ();
			isFaded = true;
		}
	}
}
