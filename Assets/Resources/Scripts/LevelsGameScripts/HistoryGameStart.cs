using UnityEngine;
using System.Collections;

public class HistoryGameStart : MonoBehaviour {

	public Transform player;
	public GameObject StartText;
	float initXPos;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		StaticData.GroundSpeed = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlaneData>().Speed;
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