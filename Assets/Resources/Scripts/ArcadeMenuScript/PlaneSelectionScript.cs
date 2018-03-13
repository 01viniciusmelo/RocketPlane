using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaneSelectionScript : MonoBehaviour {

//	public float SpeedLvl1, SpeedLvl2, SpeedLvl3, SpeedLvl4, SpeedLvl5, SpeedLvl6, SpeedLvl7;
//	public float AgilityLvl1, AgilityLvl2, AgilityLvl3, AgilityLvl4, AgilityLvl5, AgilityLvl6, AgilityLvl7;
	public float SpeedMinLevel, SpeedLevelUp;
	public float AgilityMinLevel, AgilityLevelUp;
	private Image SpeedBar, AgilityBar;
	private Text PlaneNameTxt;
	public Sprite Bar1, Bar2, Bar3, Bar4, Bar5, Bar6, Bar7;
	public GameObject[] planes;
	public float oscillationSpeed = 0.2f;
	public float oscillation = 0.05f;
	private Transform PlaneStripe;
	public int selectedPlaneIndex;
	public float ChangingSpeed = 10;
	private Animator MenuAnimator;
	bool change = false;

	// Use this for initialization
	void Start () {
//		planes = AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Textures/prefab/Planes/") as GameObject[];
		PlaneNameTxt = GameObject.Find ("PlaneNameTxt").GetComponent<Text> ();
		PlaneStripe = GameObject.Find ("PlaneStripe").GetComponent<Transform> ();
		SpeedBar = GameObject.Find("SpeedBar").GetComponent<Image>();
		AgilityBar = GameObject.Find("AgilityBar").GetComponent<Image>();
		MenuAnimator = GameObject.Find ("MainMenu").GetComponent<Animator> ();
		selectedPlaneIndex = PlayerPrefs.GetInt ("selectedPlaneIndex", 0);
//		selectedPlaneIndex = StaticData.currentData.selectedPlaneIndex;
		PlaneNameTxt.text = planes [selectedPlaneIndex].GetComponent<PlaneData>().Name;
		PlaneDataBarSelect ();
		populateStripe ();
	}
	
	// Update is called once per frame
	void Update () {
		PlanesOscillate ();
		if (change) {
			PlaneStripe.position = Vector3.MoveTowards (PlaneStripe.position, new Vector3 (15 * selectedPlaneIndex, PlaneStripe.position.y, PlaneStripe.position.z), ChangingSpeed * Time.deltaTime);
		}
		if (PlaneStripe.position == new Vector3 (15 * selectedPlaneIndex, PlaneStripe.position.y, PlaneStripe.position.z))
			change = false;
	}

	void PlanesOscillate()
	{
		if (PlaneStripe.position.y < -oscillation)
		{
			oscillationSpeed = Mathf.Abs(oscillationSpeed);
		}
		
		if (PlaneStripe.position.y > oscillation)
		{
			oscillationSpeed = Mathf.Abs(oscillationSpeed) * -1;
		}
		PlaneStripe.Translate (Vector3.up * Time.deltaTime * oscillationSpeed);
	}

	void populateStripe()
	{
		for (int i = 0; i <planes.Length; i++)
		{
			GameObject newPlane = Instantiate (planes[i] as GameObject, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			if(newPlane.transform.Find("Smoke"))
				Destroy (newPlane.transform.Find("Smoke").gameObject);
			newPlane.transform.parent = PlaneStripe;
			newPlane.transform.position = new Vector3 (-15*i, 0, 80);
		}
		PlaneStripe.position = new Vector3 (15 * selectedPlaneIndex, PlaneStripe.position.y, PlaneStripe.position.z);
	}

	public void Next()
	{
		if(selectedPlaneIndex < planes.Length - 1){
			change = true;
			selectedPlaneIndex++;
			PlaneDataBarSelect();
		}

	}

	public void Previous()
	{
		if (selectedPlaneIndex > 0) {
			change = true;
			selectedPlaneIndex--;
			PlaneDataBarSelect();
		}
	}

	public void Select()
	{
		PlayerPrefs.SetInt ("selectedPlaneIndex", selectedPlaneIndex);
//		staticData.selectedPlaneIndex = selectedPlaneIndex;
//		StaticData.currentData.selectedPlaneIndex = selectedPlaneIndex;
		StaticData.selectedPlane = planes [selectedPlaneIndex];
//		SaveLoad.Save ();
//		Application.LoadLevel("Game Scene");
		MenuAnimator.Play ("BackSelectionEnter");
	}

	public void Back()
	{
		MenuAnimator.Play ("PlaneSelectionExit");
	}

	void PlaneDataBarSelect()
	{
		PlaneNameTxt.text = planes [selectedPlaneIndex].GetComponent<PlaneData>().Name;
		Sprite selSpeedBar = Bar1;
		Sprite selAgilityBar = Bar1;
		float speed = planes[selectedPlaneIndex].GetComponent<PlaneData>().Speed;
		float agility = planes[selectedPlaneIndex].GetComponent<PlaneData>().Agility;
		
		//SPEED
		if (speed > SpeedMinLevel)
			selSpeedBar = Bar2;
		if (speed > (SpeedMinLevel + SpeedLevelUp))
			selSpeedBar = Bar3;
		if (speed > (SpeedMinLevel + (SpeedLevelUp*2)))
			selSpeedBar = Bar4;
		if (speed > (SpeedMinLevel + (SpeedLevelUp*3)))
			selSpeedBar = Bar5;
		if (speed > (SpeedMinLevel + (SpeedLevelUp*4)))
			selSpeedBar = Bar6;
		if (speed > (SpeedMinLevel + (SpeedLevelUp*5)))
			selSpeedBar = Bar7;
		
		//AGILITY
		if (agility > AgilityMinLevel)
			selAgilityBar = Bar2;
		if (agility > (AgilityMinLevel + AgilityLevelUp))
			selAgilityBar = Bar3;
		if (agility > (AgilityMinLevel + (AgilityLevelUp*2)))
			selAgilityBar = Bar4;
		if (agility > (AgilityMinLevel + (AgilityLevelUp*3)))
			selAgilityBar = Bar5;
		if (agility > (AgilityMinLevel + (AgilityLevelUp*4)))
			selAgilityBar = Bar6;
		if (agility > (AgilityMinLevel + (AgilityLevelUp*5)))
			selAgilityBar = Bar7;

		SpeedBar.sprite = selSpeedBar;
		AgilityBar.sprite = selAgilityBar;
	}
}
