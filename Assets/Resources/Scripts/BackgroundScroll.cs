using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeX;
	public bool background;
	public static bool STOP;
	
	private Vector3 startPosition;
	
	void Start ()
	{
		scrollSpeed = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlaneData> ().Speed;
		if (background)
			scrollSpeed = scrollSpeed / 2;
		STOP = false;
		startPosition = transform.position;
	}
	
	void Update ()
	{
		if (!STOP) {
			float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeX);
			transform.position = startPosition + Vector3.left * newPosition;
		}
	}

	public void setScrollSpeed(float speed)
	{
		scrollSpeed = speed;
	}
}
