using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoresUpdateScript : MonoBehaviour {

	Text Score1Text;
	Text Score2Text;
	Text Score3Text;
	Text Name1Text;
	Text Name2Text;
	Text Name3Text;

	// Use this for initialization
	void Start () {
		Score1Text = GameObject.Find ("1 result").GetComponent<Text>();
		Score2Text = GameObject.Find ("2 result").GetComponent<Text>();
		Score3Text = GameObject.Find ("3 result").GetComponent<Text>();
		Name1Text = GameObject.Find ("1 name").GetComponent<Text>();
		Name2Text = GameObject.Find ("2 name").GetComponent<Text>();
		Name3Text = GameObject.Find ("3 name").GetComponent<Text>();

		Score1Text.text = "" + PlayerPrefs.GetInt ("Best1", 0);
		Score2Text.text = "" + PlayerPrefs.GetInt ("Best2", 0);
		Score3Text.text = "" + PlayerPrefs.GetInt ("Best3", 0);
		Name1Text.text = PlayerPrefs.GetString ("Best1Name", "EMPTY");
		Name2Text.text = PlayerPrefs.GetString ("Best2Name", "EMPTY");
		Name3Text.text = PlayerPrefs.GetString ("Best3Name", "EMPTY");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
