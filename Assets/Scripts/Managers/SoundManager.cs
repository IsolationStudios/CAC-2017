using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages music and sfx
 */

namespace Managers {
	public class SoundManager : MonoBehaviour {
		public static SoundManager instance;
		public AudioSource musicPlayer;
		public AudioSource sfxPlayer;

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		public void PlaySFX(AudioClip c){
			sfxPlayer.clip = c;
			sfxPlayer.Play ();
		}
	}
}
