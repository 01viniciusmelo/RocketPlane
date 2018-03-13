using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	private Lang LMan;
	private string currentLang = "English";
	private Animator anim;
	private Text HistoryBtn, ArcadeBtn, ExitBtn;
	private Button ItalianoBtn, EnglishBtn, GermanBtn;
	private string LangFilePath;

	// Use this for initialization
	void Start () {
		HistoryBtn = GameObject.Find ("History").GetComponentInChildren<Text> ();
		ArcadeBtn = GameObject.Find ("Arcade").GetComponentInChildren<Text> ();
		ExitBtn = GameObject.Find ("Exit").GetComponentInChildren<Text> ();

		ItalianoBtn = GameObject.Find ("Italiano").GetComponent<Button>();
		EnglishBtn = GameObject.Find ("English").GetComponent<Button>();
		GermanBtn = GameObject.Find ("German").GetComponent<Button>();

		anim = gameObject.GetComponent<Animator> ();
		DataSave.current = new DataSave ();

//		LangFilePath = Path.Combine (Application.persistentDataPath, "Languages.xml");
		LangFilePath = "Scripts/Languages";
		LMan = new Lang(LangFilePath, currentLang, false);
		updateLang ();
//		StaticData.currentData = new StaticData ();
//		SaveLoad.Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void History()
	{
		Application.LoadLevel ("History Menu");
	}

	public void Arcade()
	{
		Application.LoadLevel ("Arcade Menu");
	}

	public void Exit()
	{
		anim.Play ("ConfirmExitFadeIn");
	}

	public void confirmExit(bool confirmed)
	{
		anim.Play ("ConfirmExitFadeOut");
		if (confirmed) {
			Application.Quit();
		}
	}

	public void Italiano()
	{
		currentLang = "Italiano";
		updateLang ();
	}

	public void English()
	{
		currentLang = "English";
		updateLang ();
	}

	public void German()
	{
		currentLang = "German";
		updateLang ();
	}
	
	public void updateLang()
	{
		LMan.setLanguage (LangFilePath, currentLang);
		ArcadeBtn.text = LMan.getString ("MainMenu_Arcade");
		HistoryBtn.text = LMan.getString ("MainMenu_History");
		ExitBtn.text = LMan.getString ("MainMenu_Exit");
		updateButtonColor();
	}

	public void updateButtonColor()
	{
		Color normalGreen = new Color();
		Color DarkGreen = new Color();
		Color normalRed = new Color();
		Color DarkRed = new Color();

		ColorUtility.TryParseHtmlString("00FF16FF", out normalGreen);
		ColorUtility.TryParseHtmlString("00E116FF", out DarkGreen);
		ColorUtility.TryParseHtmlString("FF3030FF", out normalRed);
		ColorUtility.TryParseHtmlString("FF0000FF", out DarkRed);

		var ItaCol = ItalianoBtn.colors;
		var EngCol = EnglishBtn.colors;
		var GerCol = GermanBtn.colors;

		switch (currentLang) {
			case "Italiano":{
				ItaCol.normalColor = normalGreen;
				ItaCol.highlightedColor = DarkGreen;
				EngCol.normalColor = normalRed;
				EngCol.highlightedColor = DarkRed;
				GerCol.normalColor = normalRed;
				GerCol.highlightedColor = DarkRed;
			}
			break;
			case "English":{
				ItaCol.normalColor = normalRed;
				ItaCol.highlightedColor = DarkRed;
				EngCol.normalColor = normalGreen;
				EngCol.highlightedColor = DarkGreen;
				GerCol.normalColor = normalRed;
				GerCol.highlightedColor = DarkRed;
			}			
			break;
			case "German":{
				ItaCol.normalColor = normalRed;
				ItaCol.highlightedColor = DarkRed;
				EngCol.normalColor = normalRed;
				EngCol.highlightedColor = DarkRed;
				GerCol.normalColor = normalGreen;
				GerCol.highlightedColor = DarkGreen;
			}
			break;
		}
		ItalianoBtn.colors = ItaCol;
		EnglishBtn.colors = EngCol;
		GermanBtn.colors = GerCol;
	}
}
