using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Contains extra math functions
 */

public static class ExtraMath {
	public static bool CheckCloseEnough(Vector3 a, Vector3 b, float threshold){
		return (Mathf.Abs (a.x - b.x) < threshold &&
			Mathf.Abs (a.y - b.y) < threshold &&
			Mathf.Abs (a.z - b.z) < threshold);
	}

	public static bool CheckCloseEnoughXZ(Vector3 a, Vector3 b, float threshold){
		return (Mathf.Abs (a.x - b.x) < threshold &&
			Mathf.Abs (a.z - b.z) < threshold);
	}

	public static int RoundToNearest(float num, int level){
		return Mathf.RoundToInt (num / level) * level;
	}
}
