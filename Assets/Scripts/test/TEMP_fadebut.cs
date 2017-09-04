using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_fadebut : MonoBehaviour {

	public void FadeBut(){
		GameObject.Find ("Player").GetComponent<PostEffectScript> ().FadeBack ();
	}
}
