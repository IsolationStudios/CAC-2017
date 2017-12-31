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
		 * 0 = music
		 * 1 = sfx alt
		 * 2 = sfx
		 * 3 = sfx2
		 */
		public AudioSource musicPlayer;
		public AudioSource[] soundPlayers;
		public AudioSource sfxAltPlayer;

		public AudioClip[] musicList;
		public AudioClip[] sfxList;

		void Awake () {
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}
		void Start(){
			soundPlayers = GetComponents<AudioSource> ();

			musicPlayer = soundPlayers [0];
			sfxAltPlayer = soundPlayers [1];
		}

		public void PlaySFX(AudioClip c, int playerNum = 2){
			AudioSource sfxPlayer = soundPlayers [playerNum];
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
		}
	}
}
