using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	Animator anim;
	public Text TotalScoreText;
	int lastScore = 0;
	string PlaneName;
	public Sprite Place1Sprite,Place2Sprite,Place3Sprite;
	public Image newHighscoreImage;
	private bool newHighscore = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		PlaneName = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlaneData> ().Name;
	}
	
	// Update is called once per frame
	void Update () {
		//If the plane falls the gameover panel appears and blocks the game when the animations finishes.
		if (PlaneCollision.gameOver) {
			lastScore = ScoreScript.Score;
			TotalScoreText.text = "SCORE: " + lastScore;
			GameObject.Find("GameInterface").GetComponent<PlaneControl>().reset();
			//Salvo eventuali HighScores
			if(lastScore > 0 && !newHighscore)
				CheckAndSaveHighscores();

			if(lastScore >= PlayerPrefs.GetInt("Best3", 0)){
				anim.SetTrigger("newHighscore");
			}else{
				//transaction to the GameOver animation
				anim.SetTrigger ("GameOverActive");	
			}
			if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("newHighscoreAnim"))
			{
				if(this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= this.anim.GetCurrentAnimatorStateInfo(0).length)
				{
					anim.SetTrigger("FromHighToGameOver");
				}
			}
			//Quando l'animazione termina blocco il gioco 
			if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("GameOver"))
			{
				if(this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= this.anim.GetCurrentAnimatorStateInfo(0).length)
				{
					Time.timeScale = 0;
				}
			}
		}
	}

	public void Restart()
	{
		//		Application.LoadLevel ("Arcade Game");
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	public void ArcadeMenu()
	{
		Application.LoadLevel ("Arcade Menu");
	}
	
	public void HistoryMenu()
	{
		Application.LoadLevel ("History Menu");
	}

	void CheckAndSaveHighscores()
	{
		int BestScore1 = PlayerPrefs.GetInt ("Best1", 0);
		string BestScore1Name = PlayerPrefs.GetString ("Best1Name", "");
		int BestScore2 = PlayerPrefs.GetInt ("Best2", 0);
		string BestScore2Name = PlayerPrefs.GetString ("Best2Name", "");
		int BestScore3 = PlayerPrefs.GetInt ("Best3", 0);
//		string BestScore3Name = PlayerPrefs.GetString ("Best3Name", "");

		if(lastScore >= BestScore1)
		{
//			if(lastScore > BestScore1)
//			{
//				PlayerPrefs.SetInt("Best3", BestScore2);
//				PlayerPrefs.SetString("Best3Name", BestScore2Name);
//				PlayerPrefs.SetInt("Best2", BestScore1);
//				PlayerPrefs.SetString("Best2Name", BestScore1Name);
//			}
			newHighscore = true;
			newHighscoreImage.sprite = Place1Sprite;
			PlayerPrefs.SetInt("Best1", lastScore);
			PlayerPrefs.SetString("Best1Name", PlaneName);
			PlayerPrefs.SetInt("Best3", BestScore2);
			PlayerPrefs.SetString("Best3Name", BestScore2Name);
			PlayerPrefs.SetInt("Best2", BestScore1);
			PlayerPrefs.SetString("Best2Name", BestScore1Name);
		}
		else
		{
			if(lastScore >= BestScore2)
			{
//				if(lastScore > BestScore2)
//				{
//					PlayerPrefs.SetInt("Best3", BestScore2);
//					PlayerPrefs.SetString("Best3Name", BestScore2Name);
//				}
				newHighscore = true;
				newHighscoreImage.sprite = Place2Sprite;
				PlayerPrefs.SetInt("Best2", lastScore);
				PlayerPrefs.SetString("Best2Name", PlaneName);
				PlayerPrefs.SetInt("Best3", BestScore2);
				PlayerPrefs.SetString("Best3Name", BestScore2Name);
			}
			else
			{
				if(lastScore >= BestScore3)
				{
					newHighscore = true;
					newHighscoreImage.sprite = Place3Sprite;
					PlayerPrefs.SetInt("Best3", lastScore);
					PlayerPrefs.SetString("Best3Name", PlaneName);
				}
			}
		}
		PlayerPrefs.Save ();
	}
}