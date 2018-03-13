using UnityEngine;
using System.Collections;

public class ChildTriggerLevels : MonoBehaviour {

	public bool TriggerEnter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && TriggerEnter) {
			GetComponentInParent<TargetCollisionLevels> ().newTriggerEvent (gameObject, other);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player" && !TriggerEnter) {
			GetComponentInParent<TargetCollisionLevels> ().newTriggerEvent (gameObject, other);
		}
	}
}
