using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour {

	Button myButton;

	public bool Completed = false;
	
	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here
		myButton.onClick.AddListener( () => {OnClickEvent();} );  // <-- you assign a method to the button OnClick event here
	}
	
	void OnClickEvent()
	{
		Application.LoadLevel ("Level " + gameObject.name);
//		GameObject.Find("LevelSelectionPanel").GetComponent<LevelSelectionPanelScript>().SelectLevel (gameObject.name);
	}

	public void setCompleted(bool completed)
	{
		Completed = completed;
	}
}
