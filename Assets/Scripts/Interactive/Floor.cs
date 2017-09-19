using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Floor that can be moved to
 */

namespace Interactive{
	[System.Obsolete("Legacy from 3D")]
	public class Floor : MonoBehaviour {
		void Awake(){
			GameManager.instance.floorLocs.Add (transform.position);
		}
	}
}