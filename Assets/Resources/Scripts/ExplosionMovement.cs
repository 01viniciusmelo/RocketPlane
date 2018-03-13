using UnityEngine;
using System.Collections;

public class ExplosionMovement : MonoBehaviour {

	private float Xspeed;

	// Use this for initialization
	void Start () {
		Xspeed = StaticData.GroundSpeed;
	}

	// Update is called once per frame
	void Update () {
		if(!PlaneCollision.gameOver)
			transform.Translate (Vector3.left * Time.deltaTime * Xspeed);
	}
}
