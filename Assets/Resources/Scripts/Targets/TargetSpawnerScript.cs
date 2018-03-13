using UnityEngine;
using System.Collections;

public class TargetSpawnerScript : MonoBehaviour {
	
	public GameObject RedTarget;
	public GameObject RedSmallTarget;
	public GameObject BlueTarget;
	public GameObject BlueSmallTarget;
	public GameObject BlackTarget;
	public GameObject BlackSmallTarget;
	public GameObject GreenTarget;
	public GameObject GreenSmallTarget;
	public GameObject LightBlueTarget;
	public GameObject LightBlueSmallTarget;
	public GameObject VioletTarget;
	public GameObject VioletSmallTarget;
	public GameObject YellowTarget;
	public GameObject YellowSmallTarget;
	public GameObject OrangeTarget;
	public GameObject OrangeSmallTarget;
	public GameObject MagentaTarget;
	public GameObject MagentaSmallTarget;

//	public bool red, blue, black, green, lightblue, violet, yellow, orange, magenta;

	private GameObject[] Targets;
	private float Ymin, Ymax;

	public int TargetColorChangeCycles = 5;
	private int TargetIndex;
	public float TargetScaleDecreasing = 0.07f;
	public float TargetMinimumScale = 0.5f;

	private float scaleValue;
	
	private GameObject selectedTarget;

	private int spawned = 0;

	private float timeUntilSpawn = 1;

	// Use this for initialization
	void Start () {
		Targets = new GameObject[] {GreenTarget, OrangeTarget, RedTarget, BlueTarget, VioletTarget, BlackTarget};

		scaleValue = 1;
		TargetIndex = 0;
//		Targets = new ArrayList ();
//		InitializeTargetsList ();
		selectTarget (Targets[0]);
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilSpawn -= Time.deltaTime;
		if(timeUntilSpawn <= 0)
		{
			controlWhichToSpawn();
			// Do your enemy spawns here
			SpawnTarget();
			// Reset for next spawn
			timeUntilSpawn = Random.Range(selectedTarget.GetComponent<TargetMovement>().minSpawnDelay,
			                              selectedTarget.GetComponent<TargetMovement>().maxSpawnDelay);
		}
	}

	private void controlWhichToSpawn()
	{
		if(scaleValue > TargetMinimumScale + TargetScaleDecreasing)
			scaleValue-=TargetScaleDecreasing;

		if (TargetIndex < Targets.Length - 1) {
			if (spawned == TargetColorChangeCycles) {
				TargetIndex++;
//				if (TargetIndex > Targets.Length - 1) {
//					TargetIndex = 0;
//					resetTargetsPrefab ();
//				}
				spawned = 0;
				scaleValue = 1f;
			}
		}
		selectTarget (Targets [TargetIndex]);
		selectedTarget.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
	}

	private void SpawnTarget()
	{
		Vector3 newPos = new Vector3 (transform.position.x, Random.Range (Ymin, Ymax), 0);
		Instantiate (selectedTarget, newPos, Quaternion.identity);
		spawned++;
	}
	
	public void selectTarget(GameObject targetToSpawn)
	{
		selectedTarget = targetToSpawn;
		Ymin = selectedTarget.GetComponent <TargetMovement>().Ymin;
		Ymax = selectedTarget.GetComponent <TargetMovement>().Ymax;
	}

	public void ResetTargetChange()
	{
		spawned = 0;
		TargetIndex = 0;
		scaleValue = 1f;
		resetTargetsPrefab ();
	}

	void InitializeTargetsList()
	{
//		if (red) {
//			Targets.Add(RedTarget);
//			Targets.Add(RedSmallTarget);
//		}
//		if (blue) {
//			Targets.Add(BlueTarget);
//			Targets.Add(BlueSmallTarget);
//		}
//		if (black) {
//			Targets.Add(BlackTarget);
//			Targets.Add(BlackSmallTarget);
//		}
//		if (lightblue) {
//			Targets.Add(LightBlueTarget);
//			Targets.Add(LightBlueSmallTarget);
//		}
//		if (green) {
//			Targets.Add(GreenTarget);
//			Targets.Add(GreenSmallTarget);
//		}
//		if (orange) {
//			Targets.Add(OrangeTarget);
//			Targets.Add(OrangeSmallTarget);
//		}
//		if (yellow) {
//			Targets.Add(YellowTarget);
//			Targets.Add(YellowSmallTarget);
//		}
//		if (violet) {
//			Targets.Add(VioletTarget);
//			Targets.Add(VioletSmallTarget);
//		}
//		if (magenta) {
//			Targets.Add(MagentaTarget);
//			Targets.Add(MagentaSmallTarget);
//		}
	}

	void resetTargetsPrefab()
	{
		RedTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		GreenTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		OrangeTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		YellowTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		BlackTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		VioletTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		MagentaTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		LightBlueTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
		BlueTarget.transform.localScale = new Vector3 (1f, 1f, 1f);
	}
}
