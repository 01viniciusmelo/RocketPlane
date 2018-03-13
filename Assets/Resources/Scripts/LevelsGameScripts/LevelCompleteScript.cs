using UnityEngine;
using System.Collections;

public class LevelCompleteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Level 1
		int LevelNumber = int.Parse (Application.loadedLevelName.Substring (6));
		DataSave.current.levels [LevelNumber-1].completed = true;
		SaveLoad.Save ();
		if (DataSave.current.NumberOfLevels > LevelNumber) {
			GameObject.Find ("NextLevel").gameObject.SetActive (true);
		} else {
			GameObject.Find ("NextLevel").gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextLevel()
	{

	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	public void Menu()
	{
		Application.LoadLevel ("History Menu");
	}
}
