using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	GameManager gM;
	private AllyVert _ally_vert;
	private AllyHorz _ally_horz;
	public static InputManager _input_instance;
	public List<GameObject> Players = new List<GameObject> ();
	private Leeroy p1_Move;
	GameObject temp_vert,temp_horz;
	public const string keyboard = "keyboard";
	public const string Horizontal = "LeftJoystickHorizontal";
	public const string Vertical = "LeftJoystickVertical";
	public const string XButton = "XButton_";
	public const string BButton = "BButton_";
	public const string AButton = "AButton_";
	public const string YButton = "YButton_";
	public const string YButton_0 = "YButton_0";
	public const string AButton_0 = "AButton_0";
	public const string BButton_0 = "BButton_0";
	public const string XButton_0 = "XButton_0";
	public static float n_players;
	//private string player_name = "player_";
	public int p;

	// Use this for initialization
	void Start () {
		gM = GameManager._gm_instance;
		Players = gM.GetPlayers ();
		p = 0;
	}

	void Awake()
	{
		_input_instance = this;
	}
	// Update is called once per frame
	void Update () {
		if (temp_vert == null || temp_horz == null )  {
			SetHorz ();
			SetVert ();
		}
		CheckKeyDown ();
		_ally_vert.MoveVertical(); 
		_ally_horz.MoveHorizontal ();

		Players = gM.GetPlayers ();

		for (int i = 0; Players.Count > i; i++) {
			Debug.Log ("Looping over movement : " + i.ToString() + " : " + Players [i].gameObject.GetComponent<Leeroy> ().GetPlayer());
			Players [i].gameObject.GetComponent<Leeroy> ().MovePlayer ();
		}

		if (gM.GetBallStatus ()) {
			// If Any of the input maps to a x,y,b,a then shoot the ball from there. 
			if(Input.GetButtonDown(XButton_0)){
				_ally_vert.XFire();
			}

			if(Input.GetButtonDown(BButton_0)){
				_ally_vert.BFire();
			}

			if(Input.GetButtonDown(YButton_0)){
				_ally_horz.YFire();
			}

			if(Input.GetButtonDown(AButton_0)){
				_ally_horz.AFire();
			}
		}
	}

	private void CheckKeyDown(){
		foreach(KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}
	}

	public void SetHorz(){
		temp_horz = GameObject.FindGameObjectWithTag ("AllyHorz");
		_ally_horz = temp_horz.GetComponent<AllyHorz> ();
	}

	public void SetVert(){
		temp_vert = GameObject.FindGameObjectWithTag ("AllyVert");
		_ally_vert = temp_vert.GetComponent<AllyVert> ();
	}
}
