using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlaneControl : MonoBehaviour {

	//PLANE DATA
	private float Agility;
	private float FallGravity;
	private bool StartFall = false;

	private Rigidbody2D rigidB;
	private Transform transf;

	public GameObject[] ControlConfigs;
	public int ControlConfigNumber = 0;

	public bool JoystickReleased = false;

	//Plane vertical speed 
//	public float AscentSpeed = 20;
//	public float DescentSpeed = 25;
	private bool moveUp;
	private bool moveDown;

	public static bool OnFalling;
	// Use this for initialization
	void Start () {
		SetControlConfig (PlayerPrefs.GetInt ("ControlConfig", 0));
		transf = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		rigidB = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>();
		Agility = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlaneData> ().Agility;
		FallGravity = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlaneData> ().FallGravity;
		OnFalling = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transf != null) {
			//Update the plane rotation 
			transf.localRotation = Quaternion.Euler (0, 0, rigidB.velocity.y);

			if (Time.timeScale == 1) {

				if(OnFalling && StartFall){
					rigidB.AddForce (Vector3.down * (Agility));
					if(rigidB.velocity.y <= 0){
						StartFall = false;
						rigidB.gravityScale = FallGravity;
					}
				}

				if(ControlConfigNumber == 0){
					//Up movement
					if (moveUp && !moveDown) {
						rigidB.AddForce (Vector3.up * Agility);
					}

					//Down movement
					if (moveDown && !moveUp) {
						rigidB.AddForce (Vector3.down * (Agility + 5));
					}

					//re-stabilization
					if (!moveUp && !moveDown) {
						if (rigidB.velocity.y > 0)
							rigidB.AddForce (Vector3.down * (Agility + 5));
						if (rigidB.velocity.y < 0)
							rigidB.AddForce (Vector3.up * Agility);
					}
				} else if (ControlConfigNumber == 1)
				{
//					var verticalForce = CrossPlatformInputManager.GetAxis("Vertical")*Agility;
					if(!OnFalling){
						if(!JoystickReleased){
							rigidB.AddForce(new Vector3(0, CrossPlatformInputManager.GetAxis("Vertical")*Agility, 0));
						}else{
							if (rigidB.velocity.y > 0)
								rigidB.AddForce (Vector3.down * (Agility + 5));
							if (rigidB.velocity.y < 0)
								rigidB.AddForce (Vector3.up * Agility);
						}
					}
				}

			}
		}

		//KEYBOARD INPUT----------------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.UpArrow)) { 
			if (!OnFalling)
				moveUp = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) { 
			moveUp = false;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (!OnFalling)
				moveDown = true;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			moveDown = false;
		}
	}
	//------------------------------------------------------------------------------------

	//Up button pressed
	public void MoveUp()
	{
		if(!OnFalling)
			moveUp = true;
	}

	//Up button released
	public void StopMoveUp()
	{
		if(!OnFalling)
			moveUp = false;
	}

	//Down button pressed
	public void MoveDown()
	{
		if(!OnFalling)
			moveDown = true;
	}

	//Down button released
	public void StopMoveDown()
	{
		if(!OnFalling)
			moveDown = false;
	}

	//Plane falling
	public void fall()
	{
		moveUp = false;
		moveDown = false;

		if (rigidB.velocity.y > 0) {
			StartFall = true;
		} else {
			StartFall = false;
			rigidB.gravityScale = FallGravity;
		}
		OnFalling = true;
	}

	public void reset()
	{
		OnFalling = false;
	}

	public void SetControlConfig(int index)
	{
		ControlConfigNumber = index;
		for (int i=0; i<ControlConfigs.Length; i++) {
			if(i == ControlConfigNumber){
				ControlConfigs[i].SetActive(true);
			}else{
				ControlConfigs[i].SetActive(false);
			}
		}
	}
}


//if(Input.GetKey(KeyCode.RightArrow)){ 
//	rigidB.AddForce(Vector3.right * speed);
//}
//if(Input.GetKey(KeyCode.LeftArrow)){
//	rigidB.AddForce(Vector3.left * speed);
//}

//			rigidB.velocity = new Vector2 (0,Mathf.Lerp (0, speed, 0.8f));
//			transform.Translate(0,speed * Time.deltaTime,0);