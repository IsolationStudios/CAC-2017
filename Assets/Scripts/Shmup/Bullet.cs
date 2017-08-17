using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup{
	public class Bullet : MonoBehaviour {

		Rigidbody2D rb;

		void Start () {
			rb = transform.GetComponent<Rigidbody2D> ();
			rb.AddForce (Vector2.up*10);

			Destroy (gameObject, 1.0f);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnCollisionEnter2D(Collision2D collider){
			Destroy (gameObject);
		}
	}
}
