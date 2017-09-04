using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Applies post-processing shader onto cam
 */

public class PostEffectScript : MonoBehaviour {
	public Material mat;

	public Material grayscaleMat;
	public Material fadeBackMat;

	private float timePassed = 0;

	void OnRenderImage(RenderTexture src, RenderTexture dest){
		Graphics.Blit (src, dest, mat);
	}

	public void FadeBack(){
		mat = fadeBackMat;
		InvokeRepeating("MoveFade", 0, 0.1f);
	}

	void MoveFade(){
		timePassed += Time.deltaTime * 5;
		mat.SetFloat ("timePassed", timePassed);

		if(timePassed > 1){
			CancelInvoke ("MoveFade");
		}
	}
}
