using UnityEngine;
using System.Collections;

public class TargetMovementLevels : MonoBehaviour {

	private float speedY, speedX;
//	public static float speedX;
	public float maxSpeed;
	float Ymin = -6.3f;
	float Ymax = 8f;
	public float minSpawnDelay,maxSpawnDelay;

	// Use this for initialization
	void Start () {
		speedY = Random.Range (-maxSpeed, maxSpeed);
		speedX = GameObject.FindGameObjectWithTag ("Ground").GetComponent<BackgroundScroll> ().scrollSpeed;
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
		transform.Translate (Vector3.left * Time.deltaTime * speedX, Space.World);
		transform.Translate (Vector3.up * Time.deltaTime * speedY, Space.World);
	}
}