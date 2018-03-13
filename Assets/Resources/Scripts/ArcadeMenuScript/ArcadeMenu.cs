using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArcadeMenu : MonoBehaviour {

	bool OptionsOpened = false;
	bool HighscoresOpened = false;
	bool ExitOpened = false;

	private Animator MenuAnimator;
	private Animator OptionsAnim;
	private Animator HighscoresAnim;
	private Animator ExitAnim;

	public GameObject HighscoresPanel;
	public GameObject HighscoresButton;

	public GameObject OptionsPanel;
	public GameObject OptionsButton;

	public GameObject ExitPanel;
	public GameObject ExitButton;

	void Start()
	{
		Time.timeScale = 1;
		OptionsAnim = OptionsPanel.GetComponent<Animator>();
		HighscoresAnim = HighscoresPanel.GetComponent<Animator>();
		ExitAnim = ExitPanel.GetComponent<Animator>();
		MenuAnimator = gameObject.GetComponent<Animator> ();
		OptionsAnim.enabled = false;
		HighscoresAnim.enabled = false;
		ExitAnim.enabled = false;
	}

//************************************************************************************************************
//**BUTTONS PRESSED*******************************************************************************************
//************************************************************************************************************

	//startGame button pressed
	public void StartGame()
	{
//		Application.LoadLevel("Game Scene");
		MenuAnimator.Play ("PlaneSelectionEnter");
	}

	//Highscores button pressed
	public void Highscores()
	{
		HighscoresAnim.enabled = true;
		if (HighscoresOpened) {
			HighscoresAnim.Play("HighscoresMoveOut");
			HighscoresOpened = false;
			HighscoresButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/highscores_btn");
		} else {
			disableAll();
			HighscoresAnim.Play("HighscoresMoveIn");
			HighscoresOpened = true;
			HighscoresButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/highscores_blink");
		}
	}

	//options button pressed
	public void Options()
	{
		OptionsAnim.enabled = true;
		if (OptionsOpened) {
			OptionsAnim.Play("OptionsMoveOut");
			OptionsOpened = false;
			OptionsButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/options_btn");
		} else {
			disableAll();
			OptionsAnim.Play("OptionsMoveIn");
			OptionsOpened = true;
			OptionsButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/options_blink");
		}
	}

	//Back button pressed
	public void Back()
	{
		Application.LoadLevel ("Main Menu");
	}

	//exit button pressed
	public void Exit()
	{
		ExitAnim.enabled = true;
		if (!ExitOpened) {
			disableAll();
			ExitAnim.Play("ExitFadeIn");
			//ExitPanel.GetComponent<Image>().CrossFadeAlpha(255,3,false);
			ExitOpened = true;
			ExitButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/exit_blink2");
		}
	}

	//confirmation button pressed (Yes or No)
	public void confirmExit(bool confirmed)
	{
		//ExitPanel.GetComponent<Image>().CrossFadeAlpha(0,3,false);
		ExitOpened = false;
		ExitAnim.Play ("ExitFadeOut");
		ExitButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/ExitBtn");
		if (confirmed) {
			Application.Quit();
		}
	}

//************************************************************************************************************
//**EXTRA FUNCTION********************************************************************************************
//************************************************************************************************************

	public void disableAll()
	{
		if (OptionsOpened) {
			OptionsAnim.Play("OptionsMoveOut");
			OptionsOpened = false;
			OptionsButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/options_btn");
		}

		if (HighscoresOpened) {
			HighscoresAnim.Play("HighscoresMoveOut");
			HighscoresOpened = false;
			HighscoresButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/Buttons/highscores_btn");
		}

	}

}
