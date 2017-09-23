using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject _ally_vert_,_ally_horz_,_walls_;
	public static GameObject _ALLY_VERT_,_ALLY_HORZ_,_WALLS_;
	public static GameManager _gm_instance;
	public static InputManager _input_instance;
	public int n_Players;
	public GameObject _leeroy;
	public ArrayList Players = new ArrayList();
	public ArrayList Colour = new ArrayList ();
	public bool ballCanFire;

	// Use this for initialization
	void Start () {
		ballCanFire = true;
		_ALLY_VERT_ = Instantiate (_ally_vert_);
		_ALLY_HORZ_ = Instantiate (_ally_horz_);
		_WALLS_ = Instantiate (_walls_);

		Colour.Add ("Color.red");
		Colour.Add ("Color.green");
		Colour.Add ("Color.magenta");
		Colour.Add ("Color.cyan");

		n_Players = 2;
		int x = 2;
		for (int i = 0; i < n_Players; i++) {
			string leeroy = "leeroy_" + i.ToString (); 
			GameObject _Leeroy = new GameObject (leeroy);
			_Leeroy = Instantiate (_leeroy, new Vector3(x, 0, 0),  Quaternion.identity);
			x -= 2;
			Players.Add (_Leeroy);
			_Leeroy.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			_Leeroy.gameObject.GetComponent<Leeroy> ().SetPlayer (i);
		}
	}
	void Awake()
	{
		_gm_instance = this;
		_input_instance = InputManager._input_instance;
	}
	// Update is called once per frame
	void Update () {
		WhoCanShoot ();
		HasAnyoneShot ();
		AnyoneLeft ();
	}

	public void WhoCanShoot ()
	{

	}
	public void HasAnyoneShot ()
	{
			
	}
	public void AnyoneLeft ()
	{

	}

	public void BallOn(){
		ballCanFire = true;
	}

	public void BallOff(){
		ballCanFire = false;
	}

	public bool GetBallStatus(){
		return ballCanFire;
	}

	public ArrayList GetPlayers(){
		return Players;
	}
		
}
