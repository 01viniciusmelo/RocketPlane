using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public static int Score;
	public static int newScore;

	// Use this for initialization
	void Start () {
		Score = 0;
		newScore = 0;
		gameObject.GetComponent<Text> ().text = "" + Score;
	}
	
	// Update is called once per frame
	void Update () {
		if (Score != newScore) {
			Score = newScore;
			gameObject.GetComponent<Text>().text = "" + Score;
		}
	}

	public static void AddScores(int scores)
	{
		newScore += scores;
	}
}
