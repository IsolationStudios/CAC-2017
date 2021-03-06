using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

/*
 * Bullet fired by enemy
 */

namespace Shmup{
	public class EnemyBullet : MonoBehaviour {
		Rigidbody2D rb;

		void Start () {
			rb = transform.GetComponent<Rigidbody2D> ();
			rb.AddForce (transform.TransformVector(Vector3.down).normalized*5);

			Destroy (gameObject, 5.0f);
		}

		void OnCollisionEnter2D(Collision2D collider){
			if (collider.gameObject.tag == "Player") {
				collider.transform.GetComponent<ShmupPlayer> ().hp--;
			}

			Destroy (gameObject);
		}
	}
}
