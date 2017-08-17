using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup{
	public class EnemyBullet : MonoBehaviour {

		Rigidbody2D rb;

		void Start () {
			rb = transform.GetComponent<Rigidbody2D> ();
			rb.AddForce (Vector2.down*5);

			Destroy (gameObject, 5.0f);
		}

		void OnCollisionEnter2D(Collision2D collider){

			if (collider.gameObject.tag == "Player") {
				print ("ouchie");
			}

			Destroy (gameObject);
		}
	}
}
