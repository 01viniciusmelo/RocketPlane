using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	private float speedY, speedX;
//	public static float speedX;
	public float maxSpeed;
	public float Ymin, Ymax;
	public float minSpawnDelay,maxSpawnDelay;

	// Use this for initialization
	void Start () {
		speedY = Random.Range (-maxSpeed, maxSpeed);
		speedX = StaticData.GroundSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (BackgroundScroll.STOP)
			speedX = 0;

		if (transform.position.y < Ymin)
		{
			speedY = Mathf.Abs(speedY);
		}
		
		if (transform.position.y > Ymax)
		{
			speedY = Mathf.Abs(speedY) * -1;
		}
		transform.Translate (Vector3.left * Time.deltaTime * speedX);
		transform.Translate (Vector3.up * Time.deltaTime * speedY);
	}
}