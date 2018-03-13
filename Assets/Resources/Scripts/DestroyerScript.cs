using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			GameObject.Find("GameInterface").GetComponent<PlaneControl> ().fall ();
		} else if (other.gameObject.tag == "Rockets") {
			other.gameObject.GetComponent<MissileMovement>().Destroyed = true;
		} else {
			if (other.gameObject.transform.parent) {
				Destroy (other.gameObject.transform.parent.gameObject);
			} else {
				Destroy (other.gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			GameObject.Find("GameInterface").GetComponent<PlaneControl> ().fall ();
		} else if (other.gameObject.tag == "Rockets") {
			other.gameObject.GetComponent<MissileMovement>().Destroyed = true;
		} else {
			if (other.gameObject.transform.parent) {
				Destroy (other.gameObject.transform.parent.gameObject);
			} else {
				Destroy (other.gameObject);
			}
		}
	}
}
