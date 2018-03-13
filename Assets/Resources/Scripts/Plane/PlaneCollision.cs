using UnityEngine;
using System.Collections;

public class PlaneCollision : MonoBehaviour {

	//Delay between smoke spawn
	public float SmokeSpawnDelay = 0.1f;
	//Smoke spawn tmp
	private float timeUntilSpawn = 0.1f;
	//falling smoke prefab
	public GameObject fallingSmoke;
	//falling smokes prefab array
	private ArrayList smokes = new ArrayList ();
	//static variable to know if the plane is exploded
	public static bool gameOver;
	//prefab explosion for the ground hit
	public GameObject GroundExplosion;
	//temp explosion for ground hit
	private GameObject newGroundExplosion;
	//Delay between explosion and plane destruction
	public float DestroyDelay = 5;

	// Use this for initialization
	void Start () {
		//clear the smokes prefab array
		smokes.Clear ();
		gameOver = false;
	}

	//collision detected
	void OnCollisionEnter2D (Collision2D collision)
	{
		//if the plane hits the ground it explodes and the game finishes
		if (collision.gameObject.tag == "Ground" && !gameOver) {
			explode();
		}
	}

	// Update is called once per frame
	void Update () {

		//update the ground explosion if exploded
		GroundExplosionUpdate ();

		//If the plane is falling
		if (PlaneControl.OnFalling && !gameOver) {
			timeUntilSpawn -= Time.deltaTime;
			if(timeUntilSpawn <= 0)
			{
				//Spawn smoke
				SpawnSmoke();
				//Reset for next spawn
				timeUntilSpawn = SmokeSpawnDelay;
			}
		}


	}

	//smoke spawn function
	void SpawnSmoke()
	{
		smokes.Add (Instantiate (fallingSmoke, transform.position, Quaternion.identity) as GameObject);
	}

	//update the layer position of the GroundExplosion and destroy the plane when the delay time is finished
	void GroundExplosionUpdate()
	{
		if (newGroundExplosion != null) {
			DestroyDelay--;
			if(DestroyDelay <= 0)
				Destroy(gameObject);
		}
	}

	//plane explodes and game finishes
	void explode()
	{
		gameOver = true;
		newGroundExplosion = Instantiate (GroundExplosion, transform.position, Quaternion.identity) as GameObject;
//		GameObject.Find ("Ground").GetComponent<BackgroundScroll> ().scrollSpeed = 0;
//		GameObject.Find ("Back").GetComponent<BackgroundScroll> ().scrollSpeed = 0;
		BackgroundScroll.STOP = true;
	}
}
