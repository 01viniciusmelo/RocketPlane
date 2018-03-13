using UnityEngine;
using System.Collections;

public class HistoryMenu : MonoBehaviour {

	public GameObject LevelSelectionPanel;
	// Use this for initialization
	void Start () {
//		LevelSelectionPanel = GameObject.Find ("LevelSelectionPanel");
		LevelSelectionPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void levelSelectPage()
	{
		LevelSelectionPanel.SetActive (true);
	}

	public void Back()
	{
		Application.LoadLevel ("Main Menu");
	}
}
