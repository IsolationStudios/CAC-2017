using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shmup;
using Player;

/*
 * Manages shmup battle
 */

namespace Managers{
	public class ShmupManager : MonoBehaviour {
		public GameObject player_obj;
		public GameObject boss_obj;

		ShmupPlayer player;
		Boss boss;

		// Use this for initialization
		void Start () {
			player = player_obj.GetComponent<ShmupPlayer> ();
			boss = boss_obj.GetComponent<Boss> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (GameState.state == GameState.State.DONE_TALKING) {
				GameState.state = GameState.State.PUZZLE;
			}

			// win
			if (boss.hp <= 0) {
				print ("you win");
				GameManager.instance.GoTo ("room01");
			}	
			else if(player.hp <= 0){
				print ("loser");
				GameManager.instance.GoTo ("room01");
			}
		}
	}
}