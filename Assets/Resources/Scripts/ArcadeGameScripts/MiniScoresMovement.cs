using UnityEngine;
using System.Collections;

public class MiniScoresMovement : MonoBehaviour {

	public float speedY;
	private float speedX;

	// Use this for initialization
	void Start () {
		speedY = 10;
		speedX = StaticData.GroundSpeed;
		var renderer = GetComponent<Renderer>();
		renderer.sortingLayerName = "Characters";
	}
	
	// Update is called once per frame
	void Update () {
		if (BackgroundScroll.STOP)
			speedX = 0;
		transform.Translate (Vector3.left * Time.deltaTime * speedX);
		transform.Translate (Vector3.up * Time.deltaTime * speedY);
	}

	public void setMiniScore(int score, Color color)
	{
		var text = GetComponent<TextMesh>();
		if (score > 0)
			text.text = "+" + score;
		else
			text.text = "" + score;
		text.color = color;
	}
}
