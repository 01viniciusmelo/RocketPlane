using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetCollision : MonoBehaviour {

	//target colliders
	public GameObject above, top, center, low, below;

	public Color PositiveMiniScoreColor;
	public int CenteredScore;

	public GameObject TargetHitExplosion;

	public GameObject MiniScore;
	
	private Collision2D newCollision;
	private Collider2D newCollider;

	public GameObject targetSpawner;

	private Text InfoText;

	private Animator UIAnimator;

	// Use this for initialization
	void Start () {
		targetSpawner = GameObject.Find ("TargetSpawner").gameObject;
		InfoText = GameObject.Find ("InfoText").GetComponent<Text> ();
		UIAnimator = GameObject.Find ("GameInterface").GetComponent<Animator> ();
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
		spawnMiniScore (CenteredScore, PositiveMiniScoreColor);
		ScoreScript.AddScores (CenteredScore);

	}

	//Passed above
	public void Above()
	{
		textBlink ("MISSED", Color.red);
		targetSpawner.GetComponent<TargetSpawnerScript> ().ResetTargetChange ();
		spawnMiniScore (-50, Color.red);
		ScoreScript.AddScores (-50);
	}

	//Passed below
	public void Below()
	{
		textBlink ("MISSED", Color.red);
		targetSpawner.GetComponent<TargetSpawnerScript> ().ResetTargetChange ();
		spawnMiniScore (-50, Color.red);
		ScoreScript.AddScores (-50);
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

	void spawnMiniScore(int score, Color color)
	{
		GameObject mini = Instantiate (MiniScore, transform.position + (transform.right * 2f) + (transform.up * 1.5f), Quaternion.identity) as GameObject;
		mini.GetComponent<MiniScoresMovement> ().setMiniScore (score, color);
	}

	void textBlink (string testo, Color colore)
	{
		UIAnimator.SetTrigger ("Reset");
		InfoText.text = testo;
		if(colore == Color.green)
			UIAnimator.Play ("GreenTextBlinking");
		if(colore == Color.red)
			UIAnimator.Play ("RedTextBlinking");
	}
}
