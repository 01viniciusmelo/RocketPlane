using UnityEngine;
using System.Collections;

public class ArcadeGameStart : MonoBehaviour {

	public Transform player;
	public GameObject StartText;
	float initXPos;

	void Awake()
	{
		if (StaticData.selectedBack == null || StaticData.selectedPlane == null) {
			Application.LoadLevel ("Arcade Menu");
		}
		else {
			GameObject background = Instantiate (StaticData.selectedBack as GameObject, new Vector3 (-5.295f, -3.144f, 10), Quaternion.identity) as GameObject;
			Destroy (background.transform.Find ("BackSel").gameObject);
			GameObject plane = Instantiate (StaticData.selectedPlane, new Vector3 (-9.25f, 0, 0), Quaternion.identity) as GameObject;
			player = plane.transform;
			StaticData.GroundSpeed = plane.GetComponent<PlaneData>().Speed;
		}
	}

	void Start()
	{
//		PlayerPrefs.DeleteAll ();
		StartText.SetActive (true);
		Time.timeScale = 0;
		StartText.SetActive (true);
		initXPos = player.transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.position = new Vector3 (player.position.x - initXPos, transform.position.y, transform.position.z);
		}
		if (Time.timeScale == 0 && StartText.activeInHierarchy && (Input.GetMouseButtonUp(0) || Input.GetKeyDown("return"))) {
			StartText.SetActive(false);
			Time.timeScale = 1;
		}
	}	
}