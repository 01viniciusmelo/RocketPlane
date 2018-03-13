using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	public GameObject PauseP;
	public GameObject ButtonPanel;
	public GameObject PauseOptionPanel;
	
	// Use this for initialization
	void Start () {
		PauseP.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnApplicationPause(bool pauseStatus) {
		if (pauseStatus)
			pause ();
	}

	public void pause()
	{
		if (Time.timeScale == 1 && !PlaneCollision.gameOver) {
			Time.timeScale = 0;
			PauseP.gameObject.SetActive (true);
		}
	}

	public void resume()
	{
		PauseP.gameObject.SetActive (false);
		Time.timeScale = 1;
	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void Options()
	{
		ButtonPanel.SetActive (false);
		PauseOptionPanel.SetActive (true);
		int Config = GameObject.Find("GameInterface").GetComponent<PlaneControl>().ControlConfigNumber;
		if (Config == 0) {
			GameObject.Find ("ButtonControl").GetComponent<Toggle> ().isOn = true;
			GameObject.Find ("JoystickControl").GetComponent<Toggle> ().isOn = false;
		}
		if (Config == 1) {
			GameObject.Find ("ButtonControl").GetComponent<Toggle> ().isOn = false;
			GameObject.Find ("JoystickControl").GetComponent<Toggle> ().isOn = true;
		}
	}

	public void ArcadeMenu()
	{
		Application.LoadLevel ("Arcade Menu");
	}

	public void HistoryMenu()
	{
		Application.LoadLevel ("History Menu");
	}

	public void OptionsBack()
	{
		int ControlConfig = 0;
		if(GameObject.Find("ButtonControl").GetComponent<Toggle>().isOn){
			ControlConfig = 0;
		}
		if (GameObject.Find ("JoystickControl").GetComponent<Toggle> ().isOn) {
			ControlConfig = 1;
		}
		PlayerPrefs.SetInt ("ControlConfig", ControlConfig);
		GameObject.Find("GameInterface").GetComponent<PlaneControl>().SetControlConfig(ControlConfig);

		ButtonPanel.SetActive (true);
		PauseOptionPanel.SetActive (false);
	}
}
