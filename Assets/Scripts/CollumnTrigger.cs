using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumnTrigger : MonoBehaviour {

	private void OnTriggerExit2D (Collider2D other) {

		if (other.GetComponent<BirdController> () != null) {

			GameControl.instance.BirdScored ();
		}
	}
}
