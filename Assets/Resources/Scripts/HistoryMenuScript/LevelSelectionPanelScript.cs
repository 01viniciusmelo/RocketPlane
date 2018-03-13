using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelSelectionPanelScript : MonoBehaviour {

	public GameObject LevelButtonPrefab;
	GameObject LevelsGrid;
	public int LevelsNumber;
//	public StaticData staticData;

	// Use this for initialization
	void Start () {
		LevelsGrid = GameObject.Find ("LevelsGrid2");
		if (SaveLoad.isFile()) {
			SaveLoad.Load ();
			if (DataSave.current.levels.Length != LevelsNumber) {
				DataSave.current.NumberOfLevels = LevelsNumber;
				DataSave.current.levels = new level[LevelsNumber];
				for (int i=0; i<LevelsNumber; i++) {
					DataSave.current.levels [i] = new level ();
//				LevelSave.current.levels[i].completed = false;
				}
				SaveLoad.Save ();
			}
		} else {
			DataSave.current.NumberOfLevels = LevelsNumber;
			DataSave.current.levels = new level[LevelsNumber];
			for (int i=0; i<LevelsNumber; i++) {
				DataSave.current.levels [i] = new level ();
				//				LevelSave.current.levels[i].completed = false;
			}
			SaveLoad.Save ();
		}
//		if (SaveLoad.isFile() == false) {
//
//		} else {
//			SaveLoad.Load ();
//		}
		updateLevelButton ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateLevelButton()
	{
		DestroyAllChildren (LevelsGrid);
		SaveLoad.Save ();
		for(int i=0; i<DataSave.current.levels.Length; i++)
		{
			GameObject newButton = Instantiate(LevelButtonPrefab, LevelsGrid.transform.position, Quaternion.identity) as GameObject;
			//			newButton.transform.parent = LevelsGrid.transform;
			newButton.transform.SetParent(LevelsGrid.transform);
			newButton.transform.localScale = new Vector3(1,1,1);
			newButton.name = "" + (i+1);
			newButton.transform.Find("Text").gameObject.GetComponent<Text>().text = "LEVEL " + (i+1);
			Color myColor = new Color();
			var colors = newButton.GetComponent<Button> ().colors;
			if(DataSave.current.levels[i].completed)
			{
				ColorUtility.TryParseHtmlString("00FF16FF", out myColor);
				colors.normalColor = myColor;
				ColorUtility.TryParseHtmlString("00E116FF", out myColor);
				colors.highlightedColor = myColor;
				//				newButton.GetComponent<Button>().colors.normalColor = myColor;
			}else{
				ColorUtility.TryParseHtmlString("FF3030FF", out myColor);
				colors.normalColor = myColor;
				ColorUtility.TryParseHtmlString("FF0000FF", out myColor);
				colors.highlightedColor = myColor;
			}
			newButton.GetComponent<Button> ().colors = colors;
			
		}
		//		foreach(level l in LevelSave.current.levels)
		//		{
		//			GameObject newButton = Instantiate(LevelButtonPrefab, LevelsGrid.transform.position, Quaternion.identity) as GameObject;
		//			newButton.transform.parent = LevelsGrid.transform;
		//			newButton.transform.localScale = new Vector3(1,1,1);
		//			newButton.name = "" + (LevelSave.current.levels.IndexOf(l)+1);
		//			newButton.transform.Find("Text").gameObject.GetComponent<Text>().text = "LEVEL " + (LevelSave.current.levels.IndexOf(l)+1);
		//
		//		}
	}

	public void Back()
	{
		gameObject.SetActive (false);
	}
	
	public void SelectLevel(string LevelNumber)
	{
		//		Application.LoadLevel ("History Level " + LevelNumber);
		string level;
		level = "History Level " + LevelNumber;
		Debug.Log (level);
		//		LevelSave.current.levels [int.Parse (LevelNumber)-1].completed = true;
		DataSave.current.setCompleted (true, int.Parse (LevelNumber) - 1);
		updateLevelButton ();
	}
	
	public void DestroyAllChildren(GameObject go)
	{
		List<GameObject> children = new List<GameObject>();
		foreach (Transform tran in go.transform)
		{      
			children.Add(tran.gameObject); 
		}
		children.ForEach(child => GameObject.Destroy(child));  
	}
}
