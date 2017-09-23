using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	GameManager gM;
	private AllyVert _ally_vert;
	private AllyHorz _ally_horz;
	public static InputManager _input_instance;
	public ArrayList Players = new ArrayList ();
	private Leeroy p1_Move;
	GameObject temp_vert,temp_horz;
	public const string keyboard = "keyboard";
	public const string p1_Horizontal = "LeftJoystickHorizontal";
	public const string p1_Vertical = "LeftJoystickVertical";
	public const string p1_XButton = "XButton";
	public const string p1_BButton = "BButton";
	public static float n_players;
	private string player_name = "player_";

	// Use this for initialization
	void Start () {
		gM = GameManager._gm_instance;
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

		if (gM.GetBallStatus ()) {
			// If Any of the input maps to a x,y,b,a then shoot the ball from there. 
			if(Input.GetKeyDown("joystick button 18")){
				_ally_vert.XFire();
			}

			if(Input.GetKeyDown("joystick button 17")){
				_ally_vert.BFire();
			}

			if(Input.GetKeyDown("joystick button 19")){
				_ally_horz.YFire();
			}

			if(Input.GetKeyDown("joystick button 16")){
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
