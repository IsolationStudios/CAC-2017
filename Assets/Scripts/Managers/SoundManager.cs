using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages music and sfx
 */

namespace Managers {
	public class SoundManager : MonoBehaviour {
		public static SoundManager instance;

		/*
		 * 1st audio src = music
		 * 2nd audio src = sfx
		 * 3rd audio src = sfx alt
		 */
		public AudioSource musicPlayer;
		public AudioSource sfxPlayer;
		public AudioSource sfxAltPlayer;

		public AudioClip[] musicList;
		public AudioClip[] sfxList;

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

		public void PlaySFXAlt(int i){
			AudioClip c = sfxList [i];
			sfxAltPlayer.clip = c;
			sfxAltPlayer.Play ();
		}

		public void PlayMusic(int i){
			AudioClip c = musicList [i];

			if (c == null) {
				musicPlayer.Stop ();
			}
			else if(c != null && c == musicPlayer.clip){
				return;
			}
				
			musicPlayer.clip = c;
			musicPlayer.Play ();

			print ("new track");
		}
	}
}
