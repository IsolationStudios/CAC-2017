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

	void OnRenderImage(RenderTexture src, RenderTexture dest){
		Graphics.Blit (src, dest, mat);
	}

	public void FadeBack(){
		mat = fadeBackMat;
	}
}
