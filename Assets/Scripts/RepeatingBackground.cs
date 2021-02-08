using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;

	void Start () {

		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
	}
	
	void Update () {

		if (transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground () {

		Vector3 groundOffset = new Vector3 (groundHorizontalLength * 2f, 0, 0);
		transform.position += groundOffset;
	}
}
