using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	public float upForce = 200f;

	private bool isAlive;
	private Rigidbody2D rbd2;
	private Animator anim;

	void Start () {
		
		isAlive = true;
		rbd2 = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update () {

		if (isAlive) {

			if (Input.GetMouseButtonDown (0)) {

				rbd2.velocity = Vector2.zero;
				rbd2.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");
			}

		}
				
	}

	void OnCollisionEnter2D () {

		isAlive = false;
		rbd2.velocity = Vector2.zero;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
