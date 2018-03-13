using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {

	public float minSpeed, maxSpeed;
	private float planeSpeed;
	private float speedY, speedX;
	public float maxInclination;
	private Vector3 direction;

	public float destroyDelay = 0.1f;
	public bool Destroyed = false;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		planeSpeed = StaticData.GroundSpeed;
		if(transform.position.y > 0)
			speedY = Random.Range (-maxInclination, 0);
		else if (transform.position.y == 0)
			speedY = Random.Range (-maxInclination, maxInclination);
		else if (transform.position.y < 0)
			speedY = Random.Range (0, maxInclination);

		speedX = Random.Range(planeSpeed + minSpeed, planeSpeed + maxSpeed);

		transform.localRotation = Quaternion.Euler(0, 0, -speedY);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left*Time.deltaTime*speedX);
		if(Destroyed){
			destroyDelay -= Time.deltaTime;
			transform.position = new Vector2 (200,200);
			if(destroyDelay <= 0)
				Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (!PlaneCollision.gameOver) {
			if (collision.gameObject == GameObject.FindGameObjectWithTag("Player").gameObject)
				GameObject.Find ("GameInterface").gameObject.GetComponent<PlaneControl> ().fall ();
		}
		if (collision.gameObject.tag == "Ground")
			Destroyed = true;
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroyed = true;
	}
}
