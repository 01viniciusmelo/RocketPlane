using UnityEngine;
using System.Collections;

public class ChildCollision : MonoBehaviour {

	public bool CollisionEnter;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player" && CollisionEnter) {
			GetComponentInParent<TargetCollision> ().newCollisionEvent (gameObject, col);
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player" && !CollisionEnter) {
			GetComponentInParent<TargetCollision> ().newCollisionEvent (gameObject, col);
		}
	}
}
