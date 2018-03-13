using UnityEngine;
using System.Collections;

public class MissileLauncherScript : MonoBehaviour {

	public GameObject Missile;
	public float minLaunchDelay;
	public float maxLaunchDelay;
	private float timeUntilLaunch = 2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeUntilLaunch -= Time.deltaTime;
		if(timeUntilLaunch <= 0 && !PlaneControl.OnFalling)
		{
			// Do your enemy spawns here
			MissileLaunch();
			// Reset for next spawn
			timeUntilLaunch = Random.Range(minLaunchDelay,maxLaunchDelay);
		}
	}

	void MissileLaunch()
	{
		Vector3 LaunchPos = new Vector3 (transform.position.x, Random.Range (-9.5f, 9.5f), 0);
		Instantiate (Missile, LaunchPos, Quaternion.identity);
	}
}
