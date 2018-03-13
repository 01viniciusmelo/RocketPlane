using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackSelectionScript : MonoBehaviour {

	public GameObject[] backs;
	private Transform BackStripe;
	public int selectedBackIndex;
	public float ChangingSpeed;
	private Animator MenuAnimator;
	private GameObject BackNameTxt;
	bool change = false;
	
	// Use this for initialization
	void Start () {
		BackNameTxt = GameObject.Find ("BackNameTxt");
		BackNameTxt.GetComponent<Renderer> ().sortingLayerName = "Characters";
		BackNameTxt.GetComponent<Renderer> ().sortingOrder = 2;
		BackStripe = GameObject.Find ("BackStripe").GetComponent<Transform> ();
		MenuAnimator = GameObject.Find ("MainMenu").GetComponent<Animator> ();
		selectedBackIndex = PlayerPrefs.GetInt ("selectedBackIndex", 0);
//		selectedBackIndex = StaticData.currentData.selectedBackIndex;
		BackNameTxt.GetComponent<TextMesh>().text = backs [selectedBackIndex].transform.name;
		populateStripe ();
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			BackStripe.position = Vector3.MoveTowards (BackStripe.position, new Vector3 (15 * selectedBackIndex, BackStripe.position.y, BackStripe.position.z), ChangingSpeed * Time.deltaTime);
		}
		if (BackStripe.position == new Vector3 (15 * selectedBackIndex, BackStripe.position.y, BackStripe.position.z))
			change = false;
	}

	void populateStripe()
	{
		for (int i = 0; i <backs.Length; i++)
		{
			GameObject newBack = Instantiate (backs[i] as GameObject, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			Destroy (newBack.transform.Find("Back").gameObject);
			Destroy (newBack.transform.Find("Ground").gameObject);
			newBack.transform.parent = BackStripe;
			newBack.transform.position = new Vector3 (-15*i, 0.6f, 80);
		}
		BackStripe.position = new Vector3 (15 * selectedBackIndex, BackStripe.position.y, BackStripe.position.z);
	}
	
	public void Next()
	{
		if(selectedBackIndex < backs.Length - 1){
			change = true;
			selectedBackIndex++;
			BackNameTxt.GetComponent<TextMesh>().text = backs [selectedBackIndex].transform.name;
		}
		
	}
	
	public void Previous()
	{
		if (selectedBackIndex > 0) {
			change = true;
			selectedBackIndex--;
			BackNameTxt.GetComponent<TextMesh>().text = backs [selectedBackIndex].transform.name;
		}
	}
	
	public void Select()
	{
		PlayerPrefs.SetInt ("selectedBackIndex", selectedBackIndex);
//		StaticData.currentData.selectedBackIndex = selectedBackIndex;
		StaticData.selectedBack = backs [selectedBackIndex];
//		SaveLoad.Save ();
		Application.LoadLevel("Arcade Game");
		//		MenuAnimator.Play ("PlaneSelectionExit");
	}

	public void Select2()
	{
		PlayerPrefs.SetInt ("selectedBackIndex", selectedBackIndex);
		//		StaticData.currentData.selectedBackIndex = selectedBackIndex;
		StaticData.selectedBack = backs [selectedBackIndex];
		//		SaveLoad.Save ();
		Application.LoadLevel("Arcade Game2");
		//		MenuAnimator.Play ("PlaneSelectionExit");
	}

	public void Select3()
	{
		PlayerPrefs.SetInt ("selectedBackIndex", selectedBackIndex);
		//		StaticData.currentData.selectedBackIndex = selectedBackIndex;
		StaticData.selectedBack = backs [selectedBackIndex];
		//		SaveLoad.Save ();
		Application.LoadLevel("Arcade Game3");
		//		MenuAnimator.Play ("PlaneSelectionExit");
	}
	
	public void Back()
	{
		MenuAnimator.Play ("BackSelectionExit");
	}
}
