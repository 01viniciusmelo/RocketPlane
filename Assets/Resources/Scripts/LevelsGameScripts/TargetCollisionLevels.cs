using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetCollisionLevels : MonoBehaviour {

	//target colliders
	GameObject above, top, center, low, below;

	public GameObject TargetHitExplosion;

	public bool lastTarget = false;
	
	private Collision2D newCollision;
	private Collider2D newCollider;

	private Text InfoText;

	private Animator InterfaceAnimator;
	private Animator UIAnimator;

	// Use this for initialization
	void Start () {
		above = gameObject.transform.Find ("Above").gameObject;
		top = gameObject.transform.Find ("TopCollider").gameObject;
		center = gameObject.transform.Find ("Center").gameObject;
		low = gameObject.transform.Find ("LowCollider").gameObject;
		below = gameObject.transform.Find ("Below").gameObject;
		InfoText = GameObject.Find ("InfoText").GetComponent<Text> ();
		InterfaceAnimator = GameObject.Find ("GameInterface").GetComponent<Animator> ();
		UIAnimator = GameObject.FindGameObjectWithTag ("UI").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Top or low border hit
	public void newCollisionEvent (GameObject child, Collision2D newcollision)
	{
		this.newCollision = newcollision;
		if (child == top)
			TopCollision ();
		if (child == low)
			LowCollision ();
	}

	//target passed above, below or centered
	public void newTriggerEvent (GameObject child, Collider2D newcollider)
	{
		this.newCollider = newcollider;
		if (!PlaneControl.OnFalling) {
			if (child == above)
				Above ();
			if (child == center)
				Center ();
			if (child == below)
				Below ();
		}
	}

	//Centered
	public void Center()
	{
		textBlink ("CENTERED", Color.green);
		if (lastTarget) {
			LevelComplete();
		}
	}

	//Passed above
	public void Above()
	{
		textBlink ("MISSED", Color.red);
		PlaneCollision.gameOver = true;
	}

	//Passed below
	public void Below()
	{
		textBlink ("MISSED", Color.red);
		PlaneCollision.gameOver = true;
	}

	//Top border hit
	public void TopCollision()
	{
		Instantiate (TargetHitExplosion, newCollision.transform.position, Quaternion.identity);
		GameObject.Find ("GameInterface").GetComponent<PlaneControl> ().fall();
	}

	//Low border hit
	public void LowCollision()
	{
		Instantiate (TargetHitExplosion, newCollision.transform.position, Quaternion.identity);
		GameObject.Find ("GameInterface").GetComponent<PlaneControl> ().fall();
	}

	void textBlink (string testo, Color colore)
	{
		InterfaceAnimator.SetTrigger ("Reset");
		InfoText.text = testo;
		if(colore == Color.green)
			InterfaceAnimator.Play ("GreenTextBlinking");
		if(colore == Color.red)
			InterfaceAnimator.Play ("RedTextBlinking");
	}

	public void LevelComplete()
	{
		UIAnimator.Play ("LevelCompletedFadeIn");
	}
}
